using UnityEngine;

public interface IPlanetSpawnPointManager 
{
    IPlanetSpawnPointPrefab PlanetSpawnPointPrefab { get; }
    ISpawner<PlanetSpawnPointCtrl> Spawner { get; }

}
