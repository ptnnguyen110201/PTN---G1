


public class ShipManagerInstaller : GameSystemInstaller
{

    public override void Install(DIContainer container)
    {
        container.Bind<IShipResourcePrefabLoader>(() => new ShipResourcePrefabLoader(PrefabType.ShipResource));
        container.Bind<ISpawner<ShipResourceCtrl>>(() => new Spawner<ShipResourceCtrl>(container.Resolve<IShipResourcePrefabLoader>()));
        container.Bind<IShipResourceManager, ShipResourceManager>();

    }

}
