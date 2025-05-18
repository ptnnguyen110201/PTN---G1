using System.Threading.Tasks;
using UnityEngine;

public class SubStationManager : ISubStationManager
{
    public ISubStationPosReader SubStationPosReader { get; private set; }
    public ISubStationPrefab SubStationPrefab { get; private set; }
    public ISubStationSpawner SubStationSpawner { get; private set; }



    public SubStationManager(
        ISubStationPrefab subStationPrefab,
        ISubStationSpawner subStationSpawner,
        ISubStationPosReader subStationPosReader)
    {
        this.SubStationPrefab = subStationPrefab;
        this.SubStationSpawner = subStationSpawner;
        this.SubStationPosReader = subStationPosReader;
    }

    public async Task Initialize()
    {
        await this.SubStationPosReader.LoadPath();
        await this.SubStationPrefab.LoadPrefabs();
        await this.SubStationSpawner.SpawnSubStation();
        Debug.Log("SubStationManager Initialized");
    }
}
