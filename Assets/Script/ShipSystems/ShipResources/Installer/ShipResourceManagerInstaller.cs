


using System.Threading.Tasks;

public class ShipResourceManagerInstaller : GameSystemInstaller
{

    public override Task Install(DIContainer container)
    {

        container.Bind<IShipResourcePrefab, ShipResourcePrefab>();
        container.Bind<IShipResourceFactoryFactory, ShipResourceFactoryFactory>();
        container.Bind<IShipResourceSpawner, ShipResourceSpawner>();
        container.Bind<IShipResourceSender, ShipResourceSender>();
        container.Bind<IShipResourceManager, ShipResourceManager>();
       
        return Task.CompletedTask;
    }

}
