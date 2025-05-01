using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStationLevel : IMainStationLevel
{
    public int RequiredResources { get; private set; } = 5;
    public int CurrentResources { get; private set; } = 0;
    public int CurrentLevel { get; private set; } = 1;
    public int MaxLevel { get; private set; } = 3;

    public void AddResources(int amount)
    {
      
        this.CurrentResources += amount;
        if (this.CurrentResources < this.RequiredResources) return;
        this.CurrentResources -= this.RequiredResources;
        this.OnLevelUp();
    }
    public void OnLevelUp()
    {
        if (this.IsMaxLevel()) return;
        this.CurrentLevel += 1;
    }
    public bool IsMaxLevel()
    {
        if (this.CurrentLevel >= this.MaxLevel) return true;
        return false;
    }


}
