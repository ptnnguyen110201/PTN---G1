


using System.Threading.Tasks;

public class SubStationInstaller : GameSystemInstaller
{

    public override Task Install(DIContainer container)
    {
        container.Bind<ISubStationPosReader, SubStationPosReader>();
        container.Bind<ISubStationPrefab, SubStationPrefab>();
        container.Bind<ISubStationFactoryFactory, SubStationFactoryFactory>();
        container.Bind<ISubStationSpawner, SubStationSpawner>();
        container.Bind<ISubStationManager, SubStationManager>();
        return Task.CompletedTask;
    }

}
