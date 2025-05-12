using UnityEngine;

public interface IPlanetPointManager : IInitializableSystem
{
    IPlanetPointPosReader PlanetPointPosReader { get; }
    IPlanetPointPrefab PlanetPointPrefab { get; }
    IPlanetPointSpawner PlanetPointSpawner { get; }

    
}
