using System.Collections.Generic;
using UnityEngine;

public class MainStationShipStorage : IMainStationShipStorage
{
    public HashSet<string> ShipStorage { get; private set; } = new HashSet<string>()
    {
        "Ship1",
     
    };
    public int maxCount { get; private set; } = 3;

    public void AddShip(string ShipID)
    {
        if (this.IsMaxShip()) return;
        this.ShipStorage.Add(ShipID);
    }
    public void RemoveShip(string ShipID)
    {
        this.ShipStorage.Remove(ShipID);
    }
    public string GetShip(string ShipID)
    {
        if (!this.ShipStorage.Contains(ShipID)) return string.Empty;
        return ShipID;
    }

    public bool IsMaxShip() => this.ShipStorage.Count >= this.maxCount;

    public HashSet<string> ExportAll() => new(this.ShipStorage);
    public void LoadFrom(HashSet<string> ShipStorage) => this.ShipStorage = new(ShipStorage);


}