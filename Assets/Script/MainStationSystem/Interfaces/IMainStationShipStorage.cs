using System.Collections.Generic;

public interface IMainStationShipStorage : IShipResourceStorage
{
    string GetShip(string ShipID);
    bool IsMaxShip();
    int maxCount { get; }
    void LoadFrom(HashSet<string> ships); 
    HashSet<string> ExportAll();
}