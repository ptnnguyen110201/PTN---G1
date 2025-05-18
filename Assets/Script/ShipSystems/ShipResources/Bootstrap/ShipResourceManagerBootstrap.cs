


using System.Threading.Tasks;

public static class ShipResourceManagerBootstrap
{
    public static async Task Initialize(DIContainer DIContainer)
    {
        ShipResourceManagerInstaller shipManagerInstaller = new ShipResourceManagerInstaller();
        await shipManagerInstaller.Install(DIContainer);


        IShipResourceManager shipResourceManager = DIContainer.Resolve<IShipResourceManager>();
        await shipResourceManager.Initialize();
    }
}

