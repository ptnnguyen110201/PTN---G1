
using UnityEngine;

public interface IShipResourceManager : IInitializableSystem
{
    IShipResourcePrefabLoader ShipResourcePrefabLoader { get; }
    IShipResourceSpawner ShipResourceSpawner { get; }
}
