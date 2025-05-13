using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine;
using System.Threading.Tasks;


public abstract class PrefabLoader : IPrefabLoader
{
    protected readonly Dictionary<string, GameObject> CachedPrefabs = new();
    public abstract PrefabType PrefabType();

    public GameObject GetPrefab(string prefabName)
    {
        if (!this.CachedPrefabs.TryGetValue(prefabName, out GameObject prefab))
        {
            Debug.LogError($"[PrefabLoader] Prefab not found in cache: {prefabName}");
            return null;
        }

        return prefab;
    }

    public Task LoadPrefabs()
    {
        string label = this.PrefabType().ToString();
        return this.LoadPrefabsByLabel(label);
    }

    public async Task LoadPrefabsByLabel(string label)
    {
        AsyncOperationHandle<IList<IResourceLocation>> handle =
            Addressables.LoadResourceLocationsAsync(label, typeof(GameObject));

        await handle.Task;

        if (handle.Status != AsyncOperationStatus.Succeeded)
        {
            Debug.LogError($"[PrefabLoader] Failed to load label: {label}");
            return;
        }

        Debug.Log($"[PrefabLoader] Found {handle.Result.Count} prefabs for label: {label}");

        foreach (var location in handle.Result)
        {
            AsyncOperationHandle<GameObject> loadHandle = Addressables.LoadAssetAsync<GameObject>(location);
            await loadHandle.Task;

            if (loadHandle.Status == AsyncOperationStatus.Succeeded)
            {
                GameObject prefab = loadHandle.Result;
                if (this.CachedPrefabs.ContainsKey(prefab.name)) continue;
                this.CachedPrefabs[prefab.name] = prefab;

            }
        }
    }

   
}
