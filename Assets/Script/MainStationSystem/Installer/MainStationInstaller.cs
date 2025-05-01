using GameSystems.Shared.SystemBase;

namespace GameSystems.Shared.Interfaces.Installer 
{
    public class MainStationInstaller : BaseInstaller<IMainStation>
    {
        public static IMainStation MainStation { get; private set; }
        public override IMainStation CreateSystem()
        {
            MainStationLevel MainStationLevel = new MainStationLevel();
            MainStation = new MainStation(MainStationLevel);
            return MainStation;
        }
    }
}