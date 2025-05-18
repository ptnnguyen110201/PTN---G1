using System.Threading.Tasks;
using UnityEngine;

public class SubStationManager : ISubStationManager
{
    public ISubStationPrefab SubStationPrefab { get; private set; }

    public ISubStationSpawner SubStationSpawner { get; private set; }

    public SubStationManager(ISubStationPrefab subStationPrefab, ISubStationSpawner subStationSpawner)
    {
        this.SubStationPrefab = subStationPrefab;
        this.SubStationSpawner = subStationSpawner;
    }

    public async Task Initialize()
    {
        await this.SubStationPrefab.LoadPrefabs();
        Debug.Log("SubStationManager Initialized");
    }
}
