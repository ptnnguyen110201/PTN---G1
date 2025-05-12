


using System.Threading.Tasks;

public static class PlanetPointManagerBootstrap
{
    public static async Task Initialize(DIContainer DIContainer)
    {
        PlanetPointInstaller planetPointInstaller = new PlanetPointInstaller();
        await planetPointInstaller.Install(DIContainer);

       
        IPlanetPointManager planetPointManager = DIContainer.Resolve<IPlanetPointManager>();
        await planetPointManager.Initialize();

    }
}

