using GameSystems.Shared.SystemBase;

namespace GameSystems.Shared.Interfaces.Installer 
{
    public class MainStationInstaller : BaseInstaller<IMainStation>
    {
        public static IMainStation MainStation { get; private set; }
        public override IMainStation CreateSystem()
        {
            MainStationLevel MainStationLevel = new MainStationLevel();
            MainStationStorage MainStationStorage = new MainStationStorage();
            MainStationUpgrade mainStationUpgrade = new MainStationUpgrade(MainStationLevel, MainStationStorage);
            MainStationShipStorage MainStationShipStorage = new MainStationShipStorage();
            MainStation = new MainStation(
                MainStationLevel, 
                MainStationStorage, 
                mainStationUpgrade,
                MainStationShipStorage);
            return MainStation;
        }
    }
}