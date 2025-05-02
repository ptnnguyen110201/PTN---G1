using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStation : IMainStation
{
    public IMainStationLevel MainStationLevel { get; private set; }
    public IMainStationStorage MainStationStorage { get; private set; }
    public IMainStationUpgarde MainStationUpgarde { get; private set; }
    public IMainStationShipStorage MainStationShipStorage { get; private set; }

    public MainStation(
        IMainStationLevel MainStationLevel, 
        IMainStationStorage MainStationStorage, 
        IMainStationUpgarde mainStationUpgarde,
        IMainStationShipStorage MainStationShipStorage)
    {
        this.MainStationLevel = MainStationLevel;
        this.MainStationStorage = MainStationStorage;
        this.MainStationUpgarde = mainStationUpgarde;
        this.MainStationShipStorage = MainStationShipStorage;
    }



    public void Initialize()
    {

    }
}
