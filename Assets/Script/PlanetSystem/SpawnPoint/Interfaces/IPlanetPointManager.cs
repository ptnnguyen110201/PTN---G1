using UnityEngine;

public interface IPlanetPointManager : IInitializableSystem, ISaveable
{
    IPlanetPointPosReader PlanetPointPosReader { get; }
    IPlanetPointPrefab PlanetPointPrefab { get; }
    IPlanetPointSpawner PlanetPointSpawner { get; }

    
}
