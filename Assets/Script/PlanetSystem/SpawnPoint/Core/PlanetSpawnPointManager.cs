public class PlanetSpawnPointManager : IPlanetSpawnPointManager
{
    public IPlanetSpawnPointPrefab PlanetSpawnPointPrefab {  get; private set; }
    public IPlanetSpawnPointSpawner PlanetSpawnPointSpawner { get; private set; }

    public PlanetSpawnPointManager(IPlanetSpawnPointPrefab planetSpawnPointPrefab, IPlanetSpawnPointSpawner PlanetSpawnPointSpawner)
    {
        this.PlanetSpawnPointPrefab = planetSpawnPointPrefab;  
        this.PlanetSpawnPointSpawner = PlanetSpawnPointSpawner;
    
    }
}