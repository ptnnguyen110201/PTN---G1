using UnityEngine;
using System.Threading.Tasks;

public class PlanetPointManager : IPlanetPointManager
{
    public IPlanetPointPrefab PlanetPointPrefab {  get; private set; }
    public IPlanetPointSpawner PlanetPointSpawner { get; private set; }
    public IPlanetPointPosReader PlanetPointPosReader { get; private set; }

    public string SaveKey => "PlanetPointManager";

    public PlanetPointManager(
        IPlanetPointPrefab PlanetPointPrefab,
        IPlanetPointSpawner PlanetPointSpawner,
        IPlanetPointPosReader PlanetPointPosReader)
    {
        this.PlanetPointPrefab = PlanetPointPrefab;  
        this.PlanetPointSpawner = PlanetPointSpawner;
        this.PlanetPointPosReader = PlanetPointPosReader;


    }

    public async Task Initialize()
    {
        await this.PlanetPointPosReader.LoadPath();
        await this.PlanetPointPrefab.LoadPrefabs();
        await this.PlanetPointSpawner.SpawnPlanetPoint();
        Debug.Log("PlanetPointManager Initialized");

    }

    public object CaptureData()
    {
        throw new System.NotImplementedException();
    }

    public void RestoreData(object data)
    {
        throw new System.NotImplementedException();
    }
}