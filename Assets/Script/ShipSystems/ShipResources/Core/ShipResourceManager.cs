
using System.Threading.Tasks;
using UnityEngine;


public class ShipResourceManager : IShipResourceManager
{
    public IShipResourcePrefab ShipResourcePrefab { get; private set; }
    public IShipResourceSpawner ShipResourceSpawner { get; private set; }
    public IShipResourceSender ShipResourceSender { get; private set; }

    public ShipResourceManager(
        IShipResourceSpawner ShipResourceSpawner,
        IShipResourcePrefab ShipResourcePrefab,
        IShipResourceSender shipResourceSender)
    {
        this.ShipResourceSpawner = ShipResourceSpawner;
        this.ShipResourcePrefab = ShipResourcePrefab;
        this.ShipResourceSender = shipResourceSender;
    }

    public async Task Initialize()
    {
        await this.ShipResourceSpawner.Initialize();
        await this.ShipResourcePrefab.Initialize();
        await this.ShipResourceSender.Initialize();
        Debug.Log("ShipResourceManager Initialized");
        
    }
}
