using System.Collections.Generic;

public interface IMainStationStorage : IResourcesStorage 
{
    Dictionary<string, int> ExportAll();
    void LoadFrom(Dictionary<string, int> map);
}