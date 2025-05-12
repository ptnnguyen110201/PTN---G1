
using System.Threading.Tasks;
using UnityEngine;


public class ShipResourceManager : IShipResourceManager
{
    public IShipResourcePrefabLoader ShipResourcePrefabLoader { get; private set; }
    public IShipResourceSpawner ShipResourceSpawner { get; private set; }

    public ShipResourceManager(IShipResourceSpawner ShipResourceSpawner, IShipResourcePrefabLoader ShipResourcePrefabLoader)
    {
        this.ShipResourceSpawner = ShipResourceSpawner;
        this.ShipResourcePrefabLoader = ShipResourcePrefabLoader;
    }

    public async Task Initialize()
    {
        await this.ShipResourcePrefabLoader.LoadPrefabs();
        Debug.Log("ShipResourceManager Initialized");
        
    }
}
