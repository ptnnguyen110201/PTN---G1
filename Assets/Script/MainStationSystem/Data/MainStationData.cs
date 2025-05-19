using System.Collections.Generic;

[System.Serializable]
public class MainStationData
{
    public int currentLevel;
    public int maxLevel = 1000;
    public Dictionary<string, int> resourceMap;
    public Dictionary<string, int> shipStorage;

}
