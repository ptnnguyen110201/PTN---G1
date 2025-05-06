using GameSystems.Shared.Interfaces.Installer;

namespace GameSystems.MainStationSystem
{
    public class MainStationInstaller : GameSystemInstaller
    {

        public override void Install(DIContainer container)
        {
            container.Bind<IMainStationLevel, MainStationLevel>();
            container.Bind<IMainStationStorage, MainStationStorage>();
            container.Bind<IMainStationUpgarde, MainStationUpgrade>();
            container.Bind<IMainStationShipStorage, MainStationShipStorage>();
            container.Bind<IMainStation, MainStation>();

        }
    }
}