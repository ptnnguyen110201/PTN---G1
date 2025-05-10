
using UnityEngine;

public interface IShipResourceManager 
{
    IShipResourcePrefabLoader ShipResourcePrefabLoader { get; }
    IShipResourceSpawner ShipResourceSpawner { get; }
}
