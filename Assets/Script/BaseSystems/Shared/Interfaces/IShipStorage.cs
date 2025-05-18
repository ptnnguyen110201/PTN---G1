using System.Collections.Generic;

public interface IShipResourceStorage
{
    HashSet<string> ShipStorage { get; }
    void AddShip(string ShipID);
    void RemoveShip(string ShipID);   
}