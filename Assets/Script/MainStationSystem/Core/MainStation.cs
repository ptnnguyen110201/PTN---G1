using System.Threading.Tasks;
using UnityEngine;

public class MainStation : IMainStation, ISaveable
{
    public IMainStationLevel MainStationLevel { get; private set; }
    public IMainStationStorage MainStationStorage { get; private set; }
    public IMainStationUpgarde MainStationUpgarde { get; private set; }
    public IMainStationShipStorage MainStationShipStorage { get; private set; }
    public IMainStationCurrency MainStationCurrency { get; private set; }
    public IMainStationPrefab MainStationPrefab { get; private set; }
    public IMainStationSpawner MainStationSpawner { get; private set; }

    public string SaveKey => "MainStation";


    public MainStation(
        IMainStationLevel mainStationLevel,
        IMainStationStorage mainStationStorage,
        IMainStationUpgarde mainStationUpgrade,
        IMainStationShipStorage mainStationShipStorage,
        IMainStationCurrency mainStationCurrency,
        IMainStationPrefab mainStationPrefab,
        IMainStationSpawner mainStationSpawner
        )
    {
        this.MainStationLevel = mainStationLevel;
        this.MainStationStorage = mainStationStorage;
        this.MainStationUpgarde = mainStationUpgrade;
        this.MainStationShipStorage = mainStationShipStorage;
        this.MainStationCurrency = mainStationCurrency;
        this.MainStationPrefab = mainStationPrefab;
        this.MainStationSpawner = mainStationSpawner;
    }

    public async Task Initialize()
    {
        await this.MainStationPrefab.LoadPrefabs();
        await this.MainStationSpawner.SpawnMainStation();
        Debug.Log("MainStation Initialized");
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
