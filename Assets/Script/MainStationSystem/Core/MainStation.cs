using UnityEngine;

public class MainStation : IMainStation, ISaveable
{
    public IMainStationLevel MainStationLevel { get; private set; }
    public IMainStationStorage MainStationStorage { get; private set; }
    public IMainStationUpgarde MainStationUpgarde { get; private set; }
    public IMainStationShipStorage MainStationShipStorage { get; private set; }

    public string SaveKey => "MainStation";

    public MainStation(
        IMainStationLevel mainStationLevel,
        IMainStationStorage mainStationStorage,
        IMainStationUpgarde mainStationUpgrade,
        IMainStationShipStorage mainStationShipStorage)
    {
        this.MainStationLevel = mainStationLevel;
        this.MainStationStorage = mainStationStorage;
        this.MainStationUpgarde = mainStationUpgrade;
        this.MainStationShipStorage = mainStationShipStorage;
    }

    public void Initialize()
    {
       
    }

    public object CaptureData()
    {
        return new MainStationData
        {
            currentLevel = MainStationLevel.CurrentLevel,
            resourceMap = MainStationStorage.ExportAll(),
            shipValue = MainStationShipStorage.ExportAll(),

        };
    }


    public void RestoreData(object data)
    {
        if (data is not MainStationData stationData) return;

        this.MainStationLevel.SetLevel(stationData.currentLevel, stationData.maxLevel);
        this.MainStationStorage.LoadFrom(stationData.resourceMap);
        this.MainStationShipStorage.LoadFrom(stationData.shipValue);
    }
}
