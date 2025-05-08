public class PlanetManager : IPlanetManager
{
    public IPlanetPrefabLoader PlanetPrefabLoader { get; private set; }
    public ISpawner<PlanetCtrl> Spawner { get; private set; }

    public PlanetManager(IPlanetPrefabLoader planetPrefabLoader, ISpawner<PlanetCtrl> spawner)
    {
        this.PlanetPrefabLoader = planetPrefabLoader;
        this.Spawner = spawner;
        this.PlanetPrefabLoader.Initialize();
    }
}