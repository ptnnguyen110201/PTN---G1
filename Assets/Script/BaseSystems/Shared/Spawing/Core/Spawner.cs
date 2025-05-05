using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Spawner<T> where T : Component, IPoolable
{
    private readonly IPrefabLoader prefabLoader;
    private readonly Dictionary<PrefabType, ObjectPool<T>> poolDictionary = new Dictionary<PrefabType, ObjectPool<T>>();
    private readonly Dictionary<PrefabType, Transform> poolHolders = new Dictionary<PrefabType, Transform>();
    public Spawner(IPrefabLoader prefabLoader)
    {
        this.prefabLoader = prefabLoader;
    }

    private Transform CreatePoolHolder(PrefabType prefabType)
    {
        if (this.poolHolders.ContainsKey(prefabType))
        {
            return this.poolHolders[prefabType];
        }

        GameObject poolHolderGO = new GameObject($"{prefabType}_PoolHolder");
        Transform holderTransform = poolHolderGO.transform;
        this.poolHolders.Add(prefabType, holderTransform);

        return holderTransform;
    }
    public async Task Preload(PrefabType prefabEnum, PrefabCode prefabCode, int preloadCount)
    {
        if (!poolDictionary.ContainsKey(prefabEnum))
        {
            GameObject prefabObject = await prefabLoader.LoadPrefabAsync(prefabEnum, prefabCode);
            if (prefabObject == null)
            {
                Debug.LogError($"Failed to preload prefab: {prefabEnum}");
                return;
            }

            T prefab = prefabObject.GetComponent<T>();
            if (prefab == null)
            {
                Debug.LogError($"Prefab {prefabEnum} does not have component {typeof(T)}");
                return;
            }

            Transform poolHolder = CreatePoolHolder(prefabEnum);
            this.poolDictionary[prefabEnum] = new ObjectPool<T>(prefab, poolHolder);
        }

        this.poolDictionary[prefabEnum].Preload(preloadCount);
    }
    public async Task<T> Spawn(PrefabType prefabEnum, PrefabCode prefabCode, Vector3 position, Quaternion rotation)
    {
        if (!this.poolDictionary.ContainsKey(prefabEnum))
        {
            GameObject prefabObject = await prefabLoader.LoadPrefabAsync(prefabEnum, prefabCode);
            if (prefabObject == null)
            {
                Debug.LogError($"Failed to load prefab: {prefabEnum}");
                return null;
            }

            T prefab = prefabObject.GetComponent<T>();
            if (prefab == null)
            {
                Debug.LogError($"Prefab {prefabEnum} does not have component {typeof(T)}");
                return null;
            }

            Transform poolHolder = CreatePoolHolder(prefabEnum);
            this.poolDictionary[prefabEnum] = new ObjectPool<T>(prefab, poolHolder);
        }

        return this.poolDictionary[prefabEnum].Spawn(position, rotation);
    }
    public List<GameObject> GetPooledObjects(PrefabType prefabType)
    {
        if (this.poolHolders.TryGetValue(prefabType, out Transform holder))
        {
            List<GameObject> pooledObjects = new List<GameObject>();

            foreach (Transform child in holder)
            {
                pooledObjects.Add(child.gameObject);
            }

            return pooledObjects;
        }

        Debug.LogWarning($"No PoolHolder found for PrefabType: {prefabType}");
        return new List<GameObject>();
    }
 
    public void Despawn(PrefabType prefabEnum, T instance)
    {
        if (!this.poolDictionary.ContainsKey(prefabEnum)) return;
        this.poolDictionary[prefabEnum].Despawn(instance);
    }
}
