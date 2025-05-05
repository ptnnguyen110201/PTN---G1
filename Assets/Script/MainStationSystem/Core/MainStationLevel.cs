using System.Collections;
using System.Collections.Generic;


public class MainStationLevel : IMainStationLevel
{
    public int CurrentLevel { get; private set; } = 1;
    public int MaxLevel { get; private set; } = 1000;

    public Dictionary<string, int> UpgradeRequirements { get; private set; } = new Dictionary<string, int>()
    {
        {"Iron", 5 }
        
    };
 
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

    public int GetUpgradeRequiredMent(string ResourceType)
    {
        if (!this.UpgradeRequirements.ContainsKey(ResourceType)) return 0;
        return this.UpgradeRequirements[ResourceType];
    }

    public void SetLevel(int CurrentLevel, int MaxLevel)
    {
        this.CurrentLevel = CurrentLevel;
        this.MaxLevel = MaxLevel;
    }

    public void Initialize()
    {
      
    }
}
