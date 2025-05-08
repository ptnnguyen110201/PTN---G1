
using UnityEngine;


public class ShipResourceManager : IShipResourceManager
{
    public IShipResourcePrefabLoader PrefabLoader { get; private set; }
    public ISpawner<ShipResourceCtrl> Spawner { get; private set; }

    public ShipResourceManager(ISpawner<ShipResourceCtrl> spawner, IShipResourcePrefabLoader prefabLoader)
    {
        this.Spawner = spawner;
        this.PrefabLoader = prefabLoader;
        this.PrefabLoader.Initialize();
    }
    public ShipResourceCtrl Spawn(PrefabCode prefabCode, Vector3 position, Quaternion rotation)
    {
        ShipResourceCtrl shipResourceCtrl = Spawner.Spawn(prefabCode, position, rotation);
        if (shipResourceCtrl == null) return null;
        shipResourceCtrl.Spawner = Spawner;
        return shipResourceCtrl;
    }
}
