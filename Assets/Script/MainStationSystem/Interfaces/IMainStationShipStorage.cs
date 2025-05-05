using System.Collections.Generic;

public interface IMainStationShipStorage : IShipStorage 
{
    bool IsMaxShip();
    HashSet<string> ExportAll();
    void LoadFrom(HashSet<string> ships);
}