


using System.Threading.Tasks;

public static class ShipManagerBootstrap
{
    public static async Task Initialize(DIContainer DIContainer)
    {
        ShipManagerInstaller shipManagerInstaller = new ShipManagerInstaller();
        await shipManagerInstaller.Install(DIContainer);
    }
}

