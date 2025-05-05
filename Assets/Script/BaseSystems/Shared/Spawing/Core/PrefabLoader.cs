using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;

public class PrefabLoader : IPrefabLoader
{
    private const string BasePath = "Assets/Prefabs";

    private readonly Dictionary<(PrefabType, PrefabCode), GameObject> cachedPrefabs = new();

    public async Task<GameObject> LoadPrefabAsync(PrefabType prefabType, PrefabCode prefabCode)
    {
        if (prefabType == PrefabType.None || prefabCode == PrefabCode.None)
        {
            Debug.LogError("Invalid prefab type or code.");
            return null;
        }

        var key = (prefabType, prefabCode);
        if (cachedPrefabs.TryGetValue(key, out var cached))
        {
            return cached;
        }

        string fullPath = $"{BasePath}/{prefabType}/{prefabCode}.prefab";
        AsyncOperationHandle<GameObject> handle = Addressables.LoadAssetAsync<GameObject>(fullPath);
        await handle.Task;

        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            GameObject prefab = handle.Result;
            cachedPrefabs[key] = prefab;
            return prefab;
        }
        else
        {
            Debug.LogError($"Failed to load prefab at path: {fullPath}");
            return null;
        }
    }

    public async Task PreloadAll()
    {
        await LoadPrefabAsync(PrefabType.Planet, PrefabCode.IronPlanet);
        await LoadPrefabAsync(PrefabType.PlanetPoint, PrefabCode.PlanetSpawnPoint);
        await LoadPrefabAsync(PrefabType.Station, PrefabCode.MainStation);
    }

    public void Initialize()
    {

        _ = PreloadAll();
    }
}
