using System.Collections.Generic;

public interface IStorage
{
    Dictionary<string, int> ResourceMap { get; }
    void AddResource(string resourceType, int resourceCount);
    void RemoveResource(string resourceType, int resourceCount);
    int GetResourceCount(string resourceType); 
}