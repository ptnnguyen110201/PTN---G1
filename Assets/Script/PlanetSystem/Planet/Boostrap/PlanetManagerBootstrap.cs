


public static class PlanetManagerBootstrap
{
    public static void Initialize(DIContainer DIContainer)
    {
        PlanetManagerInstaller planetManagerInstaller = new PlanetManagerInstaller();
        planetManagerInstaller.Install(DIContainer);
    }
}

