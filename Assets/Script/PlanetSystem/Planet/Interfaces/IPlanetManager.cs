
using UnityEngine;

public interface IPlanetManager 
{
    IPlanetPrefabLoader PlanetPrefabLoader { get; }
    IPlanetSpawner PlanetSpawner { get; }

}