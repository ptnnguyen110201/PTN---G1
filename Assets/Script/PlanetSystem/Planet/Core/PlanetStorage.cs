using System.Collections.Generic;

public class PlanetStorage : IPlanetStorage
{
    public Dictionary<string, int> ResourceMap {  get; set; } = new Dictionary<string, int>();

    public IPlanetFactory PlanetFactory { get; set; }

    public PlanetStorage(IPlanetFactory IPlanetFactory) 
    {
        this.PlanetFactory = IPlanetFactory;
    }
    public void AddResource(string resourceType, int resourceCount)
    {
        if (!this.ResourceMap.ContainsKey(resourceType))
            this.ResourceMap[resourceType] = 0;

        this.ResourceMap[resourceType] += resourceCount;
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
    }
}