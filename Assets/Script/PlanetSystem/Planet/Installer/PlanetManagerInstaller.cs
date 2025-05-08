using UnityEngine;

public class PlanetManagerInstaller : GameSystemInstaller
{
    public override void Install(DIContainer container)
    {
        container.Bind<IPlanetPrefabLoader>(() => new PlanetPrefabLoader(PrefabType.Planet));
        container.Bind<ISpawner<PlanetCtrl>>(() => new Spawner<PlanetCtrl>(container.Resolve<IPlanetPrefabLoader>()));
        container.Bind<IPlanetManager, PlanetManager>();

        container.Bind<IPlanetRespawner, PlanetRespawner>();
    }
}
