


using System.Threading.Tasks;

public static class SubStationManagerBootstrap
{
    public static async Task Initialize(DIContainer DIContainer)
    {
        SubStationInstaller subStationInstaller = new SubStationInstaller();
        await subStationInstaller.Install(DIContainer);


        ISubStationManager shipResourceManager = DIContainer.Resolve<ISubStationManager>();
        await shipResourceManager.Initialize();
    }
}

