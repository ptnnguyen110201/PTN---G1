using GameSystems.Shared.Interfaces.Installer;

namespace GameSystems.MainStationSystem
{
    public class ShipManagerInstaller : GameSystemInstaller
    {

        public override void Install(DIContainer container)
        {
            

            container.Bind<ShipEnemyPrefabLoader>(() => new ShipEnemyPrefabLoader(PrefabType.ShipEnemy));
            container.Bind<ISpawner<ShipEnemyCtrl>>(() => new Spawner<ShipEnemyCtrl>(container.Resolve<ShipEnemyPrefabLoader>()));
            container.Bind<IShipManager<ShipEnemyCtrl>, ShipEnemyManager>();




            container.Bind<ShipResourcePrefabLoader>(() => new ShipResourcePrefabLoader(PrefabType.ShipResource));
            container.Bind<ISpawner<ShipResourceCtrl>>(() => new Spawner<ShipResourceCtrl>(container.Resolve<ShipResourcePrefabLoader>()));
            container.Bind<IShipManager<ShipResourceCtrl>, ShipResourceManager>();

        }

    }
}