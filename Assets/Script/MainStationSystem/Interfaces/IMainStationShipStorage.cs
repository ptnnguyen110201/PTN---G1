using System.Collections.Generic;

public interface IMainStationShipStorage : IShipResourceStorage
{
    int GetShip(string ShipID);
    bool IsMaxShip();
    int maxCount { get; }
    void LoadFrom(Dictionary<string, int> ships);
    Dictionary<string, int> ExportAll();
}