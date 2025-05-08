
using UnityEngine;

public interface IShipResourceManager : IShipManager<ShipResourceCtrl>
{
    IShipResourcePrefabLoader PrefabLoader { get; }
    ShipResourceCtrl Spawn(PrefabCode prefabCode, Vector3 position, Quaternion rotation);
}
