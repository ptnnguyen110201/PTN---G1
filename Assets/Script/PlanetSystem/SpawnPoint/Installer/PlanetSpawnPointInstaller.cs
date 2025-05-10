using System.Threading.Tasks;
using UnityEngine;

public class PlanetSpawnPointInstaller  : GameSystemInstaller
{
    public override async Task Install(DIContainer container)
    {

        PlanetSpawnPointPrefab planetSpawnPointPrefab = new PlanetSpawnPointPrefab();
        await planetSpawnPointPrefab.LoadPrefabs();


        container.Bind<IPlanetSpawnPosReader, PlanetSpawnPosReader>();
        container.Bind<IPlanetSpawnPointPrefab>(() => planetSpawnPointPrefab);
        container.Bind<IPlanetSpawnPointSpawner>(() => new PlanetSpawnPointSpawner(planetSpawnPointPrefab, container.Resolve<IPlanetSpawnPosReader>()));
        container.Bind<IPlanetSpawnPointManager, PlanetSpawnPointManager>();

        container.Bind<IPlanetRespawnerFactory>(() =>
       new PlanetRespawnerFactory(container.Resolve<IPlanetManager>()));

    }
}
