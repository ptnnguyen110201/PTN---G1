using UnityEngine;

public class ShipResourceSpawner : Spawner<ShipResourceCtrl>, IShipResourceSpawner
{
    public IShipResourceFactoryFactory ShipResourceFactoryFactory { get; set; }
    public ShipResourceSpawner(
        IShipResourcePrefab prefabLoader, 
        IShipResourceFactoryFactory shipResourceFactoryFactory ) 
        : base(prefabLoader)
    {
        this.ShipResourceFactoryFactory = shipResourceFactoryFactory;
    }



    public ShipResourceCtrl SpawnShipResource(string prefabName, Vector3 spawnPos, Quaternion spawnRot)
    {
        ShipResourceCtrl ShipResource = this.Spawn(prefabName, spawnPos, spawnRot);
        ShipResource.InjectSpawner(this);
        return ShipResource;
    }
}