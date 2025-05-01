using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStation : IMainStation
{
    public IMainStationLevel MainStationLevel { get; private set; }
    public MainStation(IMainStationLevel MainStationLevel)
    {
        this.MainStationLevel = MainStationLevel;
    }



    public void Initialize()
    {

    }
}
