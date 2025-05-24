
using UnityEngine;

public interface IShipResourceManager : IInitializableSystem
{
    IShipResourceInfoReader ShipResourceInfoReader { get; }
    IShipResourcePrefab ShipResourcePrefab { get; }
    IShipResourceSpawner ShipResourceSpawner { get; }
    IShipResourceSender ShipResourceSender { get; }
}
