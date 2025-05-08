


public static class PlanetSpawnPointManagerBootstrap
{
    public static void Initialize(DIContainer DIContainer)
    {
        PlanetSpawnPointInstaller planetSpawnPointInstaller = new PlanetSpawnPointInstaller();
        planetSpawnPointInstaller.Install(DIContainer);
    }
}

