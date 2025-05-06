using GameSystems.Shared.SystemBase;
using UnityEngine;

public interface IShipManager <T> where T : Component, IPoolable
{
    IPrefabLoader PrefabLoader { get; }
    ISpawner<T> Spawner { get; }
}