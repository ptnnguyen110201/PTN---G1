
using UnityEngine;

public interface IShipResourceManager : IInitializableSystem
{
    IShipResourcePrefab ShipResourcePrefab { get; }
    IShipResourceSpawner ShipResourceSpawner { get; }
    IShipResourceSender ShipResourceSender { get; }
}
