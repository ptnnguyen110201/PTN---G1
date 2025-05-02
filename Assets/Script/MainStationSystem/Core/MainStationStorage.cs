using System.Collections.Generic;
using GameSystems.Shared.Events;

public class MainStationStorage : IMainStationStorage
{
    public Dictionary<string,int> ResourceMap {  get; private set; } = new Dictionary<string, int>();
    public void AddResource(string resourceType, int resourceCount)
    {
        if (!this.ResourceMap.ContainsKey(resourceType))
            this.ResourceMap[resourceType] = 0;

        this.ResourceMap[resourceType] += resourceCount;
        EventManager.Invoke(EventKeys.OnResourceChanged, resourceType, this.ResourceMap[resourceType]);
    }

    public int GetResourceCount(string resourceType)
    {
        if (!this.ResourceMap.ContainsKey(resourceType)) return 0;
        return this.ResourceMap[resourceType];

    }

    public void RemoveResource(string resourceType, int resourceCount)
    {
        if (!this.ResourceMap.ContainsKey(resourceType)) return;
        if (this.ResourceMap[resourceType] < resourceCount) return;
        this.ResourceMap[resourceType] -= resourceCount;
        EventManager.Invoke(EventKeys.OnResourceChanged, resourceType, this.ResourceMap[resourceType]);
    }
}