using System.Collections.Generic;

public interface IShipResourceStorage
{
    Dictionary<string, int> ShipStorage { get; }
    void AddShip();
    void RemoveShip(string ShipID);   
}