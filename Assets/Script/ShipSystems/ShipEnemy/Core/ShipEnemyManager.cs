using UnityEngine;

public class ShipEnemyManager : IShipManager<ShipEnemyCtrl>
{
    public IPrefabLoader PrefabLoader { get; private set; }
    public ISpawner<ShipEnemyCtrl> Spawner {  get; private set; }


    public ShipEnemyManager(ShipEnemyPrefabLoader prefabLoader, ISpawner<ShipEnemyCtrl> spawner)
    {
        this.PrefabLoader = prefabLoader;
        this.Spawner = spawner;

        this.PrefabLoader.Initialize();
    }



}
