using GameSystems.Shared.Interfaces.Installer;

namespace GameSystems.MainStationSystem
{
    public static class MainStationBootstrap
    {
        public static void Initialize(DIContainer DIContainer)
        {
            MainStationInstaller installer = new MainStationInstaller();
            installer.Install(DIContainer);

            MainStation mainStation = DIContainer.Resolve<MainStation>();
            mainStation.Initialize();

        }
    }
}
