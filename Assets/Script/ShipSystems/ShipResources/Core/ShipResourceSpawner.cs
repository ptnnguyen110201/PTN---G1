using UnityEngine;

public class ShipResourceSpawner : Spawner<ShipResourceCtrl>, IShipResourceSpawner
{
   
    public ShipResourceSpawner( IShipResourcePrefab prefabLoader): base(prefabLoader)

    {
       
    }



    public ShipResourceCtrl SpawnShipResource(string prefabName, Vector3 spawnPos, Quaternion spawnRot)
    {
        ShipResourceCtrl ShipResource = this.Spawn(prefabName, spawnPos, spawnRot);
        return ShipResource;
    }
}