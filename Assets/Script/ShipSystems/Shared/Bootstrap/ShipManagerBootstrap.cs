using GameSystems.Shared.Interfaces.Installer;

namespace GameSystems.MainStationSystem
{
    public static class ShipManagerBootstrap
    {
        public static void Initialize(DIContainer DIContainer)
        {
            ShipManagerInstaller shipManagerInstaller = new ShipManagerInstaller();
            shipManagerInstaller.Install(DIContainer);
        }
    }
}
