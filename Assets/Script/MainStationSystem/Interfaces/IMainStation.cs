

using UnityEngine;

public interface IMainStation : IInitializableSystem
{
    public IMainStationPrefab MainStationPrefab { get; }
    public IMainStationSpawner MainStationSpawner { get; }
    public IMainStationLevel MainStationLevel { get; }    
    public IMainStationStorage MainStationStorage { get; }
    public IMainStationUpgarde MainStationUpgarde { get; }
    public IMainStationShipStorage MainStationShipStorage { get; }
    public IMainStationCurrency MainStationCurrency { get; }
    public ISaveRegistry SaveRegistry { get; }
}
