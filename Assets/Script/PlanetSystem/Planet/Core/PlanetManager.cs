public class PlanetManager : IPlanetManager
{
    public IPlanetPrefabLoader PlanetPrefabLoader { get; private set; }
    public IPlanetSpawner PlanetSpawner { get; private set; }

    public PlanetManager(IPlanetPrefabLoader planetPrefabLoader, IPlanetSpawner PlanetSpawner)
    {
        this.PlanetPrefabLoader = planetPrefabLoader; 
        this.PlanetSpawner = PlanetSpawner;

    }
}