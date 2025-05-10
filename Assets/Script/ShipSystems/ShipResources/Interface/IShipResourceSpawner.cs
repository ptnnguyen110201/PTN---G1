using UnityEngine;

public interface IShipResourceSpawner : ISpawner<ShipResourceCtrl> 
{
    void SendShipToPlanet(Transform PlanetPos, Vector3 SpawnPos, Vector3 SpawnRot);
}