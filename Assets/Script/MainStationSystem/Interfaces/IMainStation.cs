
using GameSystems.Shared.SystemBase;

public interface IMainStation : IInitializableSystem
{
    public IMainStationLevel MainStationLevel { get; }    
    public IMainStationStorage MainStationStorage { get; }
    public IMainStationUpgarde MainStationUpgarde { get; }
    public IMainStationShipStorage MainStationShipStorage { get; }
}
