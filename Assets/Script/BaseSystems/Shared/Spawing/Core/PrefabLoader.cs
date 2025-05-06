using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine;
using System.Threading.Tasks;

public class PrefabLoader : IPrefabLoader
{
    protected readonly Dictionary<PrefabCode, GameObject> CachedPrefabs = new();
    public PrefabType PrefabType { get; private set; }

    public PrefabLoader(PrefabType prefabType)
    {
        this.PrefabType = prefabType;
    }

    public GameObject GetPrefab(PrefabCode prefabCode)
    {
        if (!this.CachedPrefabs.TryGetValue(prefabCode, out GameObject prefab))
        {
            Debug.LogError($"[PrefabLoader] Prefab not found in cache: {prefabCode}");
            return null;
        }

        return prefab;
    }

    public Task LoadPrefabs(PrefabType prefabType)
    {
        string label = prefabType.ToString(); 
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
                string name = prefab.name;

                if (!System.Enum.TryParse(name, out PrefabCode prefabCode)) continue;

                if (this.CachedPrefabs.ContainsKey(prefabCode)) continue;
                this.CachedPrefabs[prefabCode] = prefab;

            }
        }
    }

    public void Initialize()
    {
        _ = this.LoadPrefabs(this.PrefabType);
    }
}
