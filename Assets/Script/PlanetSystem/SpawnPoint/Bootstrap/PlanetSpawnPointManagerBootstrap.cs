


using System.Threading.Tasks;

public static class PlanetSpawnPointManagerBootstrap
{
    public static async Task Initialize(DIContainer DIContainer)
    {
        PlanetSpawnPointInstaller planetSpawnPointInstaller = new PlanetSpawnPointInstaller();
        await planetSpawnPointInstaller.Install(DIContainer);
    }
}

