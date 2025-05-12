
using UnityEngine;

public interface IPlanetManager : IInitializableSystem
{
    IPlanetPrefabLoader PlanetPrefabLoader { get; }
    IPlanetSpawner PlanetSpawner { get; }

}