


using System.Threading.Tasks;

public class ShipManagerInstaller : GameSystemInstaller
{

    public override async Task Install(DIContainer container)
    {

        ShipResourcePrefabLoader shipResourcePrefabLoader = new ShipResourcePrefabLoader();
        await shipResourcePrefabLoader.LoadPrefabs();

        container.Bind<IShipResourcePrefabLoader>(() => shipResourcePrefabLoader);
        container.Bind<IShipResourceSpawner>(() => new ShipResourceSpawner(shipResourcePrefabLoader));
        container.Bind<IShipResourceManager, ShipResourceManager>();

    }

}
