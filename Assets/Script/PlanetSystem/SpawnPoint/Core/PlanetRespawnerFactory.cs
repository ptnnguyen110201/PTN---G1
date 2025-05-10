public class PlanetRespawnerFactory : IPlanetRespawnerFactory
{
    private readonly IPlanetManager planetManager;

    public PlanetRespawnerFactory(IPlanetManager planetManager)
    {
        this.planetManager = planetManager;
    }

    public IPlanetRespawner Create(PlanetSpawnPointCtrl spawnPoint)
    {
        return new PlanetRespawner(this.planetManager, spawnPoint);
    }
}
