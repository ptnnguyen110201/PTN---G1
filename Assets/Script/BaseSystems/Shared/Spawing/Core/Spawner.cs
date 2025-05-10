using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : ISpawner<T> where T : Component, IPoolable
{
    private readonly IPrefabLoader prefabLoader;
    private readonly Dictionary<PrefabCode, ObjectPool<T>> poolDictionary = new();
    private readonly Dictionary<PrefabType, Transform> poolHolders = new();
    private readonly Dictionary<T, PrefabCode> instanceToCode = new();

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

        GameObject poolHolderGO = new GameObject($"{this.prefabLoader.PrefabType()}PoolHolder");
        Transform holderTransform = poolHolderGO.transform;
        this.poolHolders.Add(this.prefabLoader.PrefabType(), holderTransform);

        return holderTransform;
    }

    public void Preload(PrefabCode prefabCode, int preloadCount)
    {
        if (!this.poolDictionary.ContainsKey(prefabCode))
        {
            GameObject prefabObject = this.prefabLoader.GetPrefab(prefabCode);
            if (prefabObject == null)
            {
                Debug.LogError($"[Spawner] Failed to preload prefab: {prefabCode}");
                return;
            }

            T prefab = prefabObject.GetComponent<T>();
            if (prefab == null)
            {
                Debug.LogError($"[Spawner] Prefab {prefabCode} does not have component {typeof(T)}");
                return;
            }

            Transform poolHolder = this.CreatePoolHolder();
            this.poolDictionary[prefabCode] = new ObjectPool<T>(prefab, poolHolder);
        }

        this.poolDictionary[prefabCode].Preload(preloadCount);
    }

    public T Spawn(PrefabCode prefabCode, Vector3 position, Quaternion rotation)
    {
        if (!this.poolDictionary.ContainsKey(prefabCode))
        {
            GameObject prefabObject = this.prefabLoader.GetPrefab(prefabCode);
            if (prefabObject == null)
            {
                Debug.LogError($"[Spawner] Failed to spawn prefab: {prefabCode}");
                return null;
            }

            T prefab = prefabObject.GetComponent<T>();
            if (prefab == null)
            {
                Debug.LogError($"[Spawner] Prefab {prefabCode} does not have component {typeof(T)}");
                return null;
            }

            Transform poolHolder = this.CreatePoolHolder();
            this.poolDictionary[prefabCode] = new ObjectPool<T>(prefab, poolHolder);
        }

        T instance = this.poolDictionary[prefabCode].Spawn(position, rotation);
        this.instanceToCode[instance] = prefabCode;

        return instance;
    }

    public void Despawn(T instance)
    {
        if (this.instanceToCode.TryGetValue(instance, out PrefabCode prefabCode) &&
            this.poolDictionary.TryGetValue(prefabCode, out ObjectPool<T> pool))
        {
            pool.Despawn(instance);
            this.instanceToCode.Remove(instance);
        }
        else
        {
            Debug.LogWarning($"[Spawner] Attempted to despawn unknown or unmanaged instance: {instance?.name}");
        }
    }

 
}
