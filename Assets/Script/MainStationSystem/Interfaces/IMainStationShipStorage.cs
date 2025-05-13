using System.Collections.Generic;

public interface IMainStationShipStorage : IShipStorage
{
    bool IsMaxShip();
    HashSet<string> ExportAll();

    int maxCount { get; }
    void LoadFrom(HashSet<string> ships);
}