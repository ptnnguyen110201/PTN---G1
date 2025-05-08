
using UnityEngine;

public interface IPlanetManager 
{
    IPlanetPrefabLoader PlanetPrefabLoader { get; }
    ISpawner<PlanetCtrl> Spawner { get; }

}