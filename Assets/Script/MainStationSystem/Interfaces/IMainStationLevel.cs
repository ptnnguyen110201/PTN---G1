using System.Collections.Generic;

public interface IMainStationLevel : ILevel 
{
    Dictionary<string, int> UpgradeRequirements { get; }
    int GetUpgradeRequiredMent(string ResourceType);

    void SetLevel(int CurrentLevel, int MaxLevel);


    
}