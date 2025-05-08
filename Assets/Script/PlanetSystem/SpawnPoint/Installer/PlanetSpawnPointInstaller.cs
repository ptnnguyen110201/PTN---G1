using UnityEngine;

public class PlanetSpawnPointInstaller  : GameSystemInstaller
{
    public override void Install(DIContainer container)
    {


        container.Bind<IPlanetSpawnPointPrefab>(() => new PlanetSpawnPointPrefab(PrefabType.PlanetSpawnPoint));
        container.Bind<ISpawner<PlanetSpawnPointCtrl>>(() => new Spawner<PlanetSpawnPointCtrl>(container.Resolve<IPlanetSpawnPointPrefab>()));
        container.Bind<IPlanetSpawnPointManager, PlanetSpawnPointManager>();

    }
}
