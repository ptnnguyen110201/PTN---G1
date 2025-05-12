using UnityEngine;

public class ShipResourceSpawner : Spawner<ShipResourceCtrl>, IShipResourceSpawner
{
    public ShipResourceSpawner(IShipResourcePrefabLoader prefabLoader) : base(prefabLoader)
    {
    }

}