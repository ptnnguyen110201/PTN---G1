using UnityEngine;

public interface IShipResourceSpawner : ISpawner<ShipResourceCtrl> 
{
    public ShipResourceCtrl SpawnShipResource(string prefabName, Vector3 spawnPos, Quaternion spawnRot);
    IShipResourceFactoryFactory ShipResourceFactoryFactory { get; }

}