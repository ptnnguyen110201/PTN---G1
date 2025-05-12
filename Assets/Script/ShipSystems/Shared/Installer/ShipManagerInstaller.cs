


using System.Threading.Tasks;

public class ShipManagerInstaller : GameSystemInstaller
{

    public override Task Install(DIContainer container)
    {

        container.Bind<IShipResourcePrefabLoader, ShipResourcePrefabLoader>();
        container.Bind<IShipResourceSpawner, ShipResourceSpawner>();
        container.Bind<IShipResourceManager, ShipResourceManager>();
        return Task.CompletedTask;
    }

}
