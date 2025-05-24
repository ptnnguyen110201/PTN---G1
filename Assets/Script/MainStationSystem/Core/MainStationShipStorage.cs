using System.Collections.Generic;
using UnityEngine;

public class MainStationShipStorage : IMainStationShipStorage
{
    public Dictionary<string, int> ShipStorage { get; private set; } = new Dictionary<string, int>
    {
        { "Ship1", 1 },
        { "Ship2", 2 },
        { "Ship3", 3 },
    };


    protected string shipID = "Ship";
    public int maxCount { get; private set; } = 3;

    public void AddShip()
    {
        if (this.IsMaxShip()) return;

        string newID = this.shipID;
        int suffix = 1;

        while (this.ShipStorage.ContainsKey(newID))
        {
            newID = $"{this.shipID}{suffix}";
            suffix++;
        }

        this.ShipStorage[newID] = 1;
    }

    public void RemoveShip(string ShipID)
    {
        if (!this.ShipStorage.ContainsKey(shipID)) return;
        this.ShipStorage.Remove(ShipID);
    }
    public int GetShip(string shipID)
    {
        if (!this.ShipStorage.TryGetValue(shipID, out int level))
            return 0; 

        return level;
    }

    public bool IsMaxShip() => this.ShipStorage.Count >= this.maxCount;

    public Dictionary<string, int> ExportAll() => new(this.ShipStorage);
    public void LoadFrom(Dictionary<string, int> ShipStorage) => this.ShipStorage = new(ShipStorage);


}