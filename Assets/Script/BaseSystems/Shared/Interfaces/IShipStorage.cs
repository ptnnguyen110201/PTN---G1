using System.Collections.Generic;

public interface IShipStorage
{
    HashSet<string> ShipStorage { get; }
    void AddShip(string ShipID);
    void RemoveShip(string ShipID);   
}