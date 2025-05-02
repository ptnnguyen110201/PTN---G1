using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStationUpgrade : IMainStationUpgarde
{
    public IMainStationLevel MainStationLevel { get; private set; }
    public IMainStationStorage MainStationStorage { get; private set; }


    public MainStationUpgrade(
        IMainStationLevel mainStationLevel, 
        IMainStationStorage mainStationStorage)
    {
        MainStationLevel = mainStationLevel;
        MainStationStorage = mainStationStorage;
    }

    public bool CanUpgrade()
    {
        if (this.MainStationLevel.IsMaxLevel()) return false;
        foreach (var req in MainStationLevel.UpgradeRequirements)
        {
            if (this.MainStationStorage.GetResourceCount(req.Key) < req.Value)
                return false;
        }
        return true;
    }

    public bool TryUpgrade()
    {
        if (!this.CanUpgrade()) return false;

        foreach (var req in this.MainStationLevel.UpgradeRequirements)
        {
            this.MainStationStorage.RemoveResource(req.Key, req.Value);
        }

        this.MainStationLevel.OnLevelUp();
        return true;
    }
}
