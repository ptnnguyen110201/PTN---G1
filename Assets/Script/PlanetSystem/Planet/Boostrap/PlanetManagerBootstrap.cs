


using System.Threading.Tasks;

public static class PlanetManagerBootstrap
{
    public static async Task Initialize(DIContainer DIContainer)
    {
        PlanetManagerInstaller planetManagerInstaller = new PlanetManagerInstaller();
        await planetManagerInstaller.Install(DIContainer);
    }
}

