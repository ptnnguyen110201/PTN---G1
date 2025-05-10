using UnityEngine;

public interface IPlanetSpawnPointManager 
{
    IPlanetSpawnPointPrefab PlanetSpawnPointPrefab { get; }
    IPlanetSpawnPointSpawner PlanetSpawnPointSpawner { get; }

}
