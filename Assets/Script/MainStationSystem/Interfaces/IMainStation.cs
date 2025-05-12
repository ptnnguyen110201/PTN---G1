

using UnityEngine;

public interface IMainStation : IInitializableSystem
{
    public IMainStationLevel MainStationLevel { get; }    
    public IMainStationStorage MainStationStorage { get; }
    public IMainStationUpgarde MainStationUpgarde { get; }
    public IMainStationShipStorage MainStationShipStorage { get; }
    public IMainStationCurrency MainStationCurrency { get; }
}
