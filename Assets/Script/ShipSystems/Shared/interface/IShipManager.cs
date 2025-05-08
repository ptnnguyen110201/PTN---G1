
using UnityEngine;

public interface IShipManager <T> where T : Component, IPoolable 
{
    ISpawner<T> Spawner { get; }


}