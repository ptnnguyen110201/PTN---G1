using System.Collections.Generic;
using GameSystems.Shared.Events;

public class MainStationShipStorage : IMainStationShipStorage
{

    public HashSet<string> ShipStorage { get; private set; } = new HashSet<string>();
    public int maxCount = 5;

    public void AddShip(string ShipID)
    {
  
        if (this.IsMaxShip()) return; 
        this.ShipStorage.Add(ShipID);
    }
    public void RemoveShip(string ShipID)
    {
        this.ShipStorage.Remove(ShipID);
    }
    public bool IsMaxShip() => this.ShipStorage.Count >= this.maxCount;

    public HashSet<string> ExportAll() => new(this.ShipStorage);
    public void LoadFrom(HashSet<string> ShipStorage) => this.ShipStorage = new(ShipStorage);
    
        
    
}