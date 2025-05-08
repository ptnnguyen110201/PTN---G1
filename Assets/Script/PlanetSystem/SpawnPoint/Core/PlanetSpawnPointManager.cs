public class PlanetSpawnPointManager : IPlanetSpawnPointManager
{
    public IPlanetSpawnPointPrefab PlanetSpawnPointPrefab {  get; private set; }
    public ISpawner<PlanetSpawnPointCtrl> Spawner { get; private set; }


    public PlanetSpawnPointManager(IPlanetSpawnPointPrefab planetSpawnPointPrefab, ISpawner<PlanetSpawnPointCtrl> spawner)
    {
        this.PlanetSpawnPointPrefab = planetSpawnPointPrefab;
        this.Spawner = spawner;
        this.PlanetSpawnPointPrefab.Initialize();
    }
}