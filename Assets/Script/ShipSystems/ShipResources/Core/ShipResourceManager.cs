using UnityEngine;

public class ShipResourceManager : IShipManager<ShipResourceCtrl>
{
    public IPrefabLoader PrefabLoader { get; private set; }
    public ISpawner<ShipResourceCtrl> Spawner {  get; private set; }


    public ShipResourceManager(ShipResourcePrefabLoader prefabLoader, ISpawner<ShipResourceCtrl> spawner)
    {
        this.PrefabLoader = prefabLoader;
        this.Spawner = spawner;

        this.PrefabLoader.Initialize();
    }



}
