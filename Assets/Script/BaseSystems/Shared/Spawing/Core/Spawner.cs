using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Spawner<T> : ISpawner<T> where T : Component, IPoolable
{
    private readonly IPrefabLoader prefabLoader;
    private readonly Dictionary<string, ObjectPool<T>> poolDictionary = new();
    private readonly Dictionary<PrefabType, Transform> poolHolders = new();
    private readonly Dictionary<T, string> instanceToCode = new();

    public Spawner(IPrefabLoader prefabLoader)
    {
        this.prefabLoader = prefabLoader;
    }

    private Transform CreatePoolHolder()
    {
        if (this.poolHolders.ContainsKey(this.prefabLoader.PrefabType()))
        {
            return this.poolHolders[this.prefabLoader.PrefabType()];
        }

        GameObject poolHolderGO = new GameObject($"{this.prefabLoader.PrefabType()}");
        Transform holderTransform = poolHolderGO.transform;
        this.poolHolders.Add(this.prefabLoader.PrefabType(), holderTransform);

        return holderTransform;
    }

    public Task Preload(string prefabName, int preloadCount)
    {
        if (!this.poolDictionary.ContainsKey(prefabName))
        {
            GameObject prefabObject = this.prefabLoader.GetPrefab(prefabName);
            if (prefabObject == null)
            {
                Debug.LogError($"[Spawner] Failed to preload prefab: {prefabName}");
                return Task.CompletedTask;
            }

            T prefab = prefabObject.GetComponent<T>();
            if (prefab == null)
            {
                Debug.LogError($"[Spawner] Prefab {prefabName} does not have component {typeof(T)}");
                return Task.CompletedTask;
            }

            Transform poolHolder = this.CreatePoolHolder();
            this.poolDictionary[prefabName] = new ObjectPool<T>(prefab, poolHolder);
        }

        this.poolDictionary[prefabName].Preload(preloadCount);
        return Task.CompletedTask;
    }

    public T Spawn(string prefabName, Vector3 position, Quaternion rotation)
    {
        if (!this.poolDictionary.ContainsKey(prefabName))
        {
            GameObject prefabObject = this.prefabLoader.GetPrefab(prefabName);
            if (prefabObject == null)
            {
                Debug.LogError($"[Spawner] Failed to spawn prefab: {prefabName}");
                return null;
            }

            T prefab = prefabObject.GetComponent<T>();
            if (prefab == null)
            {
                Debug.LogError($"[Spawner] Prefab {prefabName} does not have component {typeof(T)}");
                return null;
            }

            Transform poolHolder = this.CreatePoolHolder();
            this.poolDictionary[prefabName] = new ObjectPool<T>(prefab, poolHolder);
        }

        T instance = this.poolDictionary[prefabName].Spawn(position, rotation);
        this.instanceToCode[instance] = prefabName;

        return instance;
    }

    public void Despawn(T instance)
    {
        if (this.instanceToCode.TryGetValue(instance, out string prefabName) &&
            this.poolDictionary.TryGetValue(prefabName, out ObjectPool<T> pool))
        {
            pool.Despawn(instance);
            this.instanceToCode.Remove(instance);
        }
    }

    public Task Initialize()
    {
        return Task.CompletedTask;
    }
}
