


using System.Threading.Tasks;

public class ShipResourceManagerInstaller : GameSystemInstaller
{

    public override Task Install(DIContainer container)
    {

        container.Bind<IShipResourceInfoReader, ShipResourceInfoReader>();
        container.Bind<IShipResourcePrefab, ShipResourcePrefab>();
        container.Bind<IShipResourceSpawner, ShipResourceSpawner>();
        container.Bind<IShipFactoryFactory, ShipFactoryFactory>();
        container.Bind<IShipResourceSender, ShipResourceSender>();
        container.Bind<IShipResourceManager, ShipResourceManager>();

        return Task.CompletedTask;
    }

}
