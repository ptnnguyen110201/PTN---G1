using UnityEngine;

public class ShipResourceSpawner : Spawner<ShipResourceCtrl>, IShipResourceSpawner
{
    public ShipResourceSpawner(IPrefabLoader prefabLoader) : base(prefabLoader)
    {
    }

    public void SendShipToPlanet(Transform PlanetPos, Vector3 SpawnPos, Vector3 SpawnRot)
    {
        
    }
}