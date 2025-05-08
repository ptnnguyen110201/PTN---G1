
using UnityEngine;

public interface ISpawner<T> where T : Component, IPoolable
{
    void Preload(PrefabCode prefabCode, int preloadCount);
    T Spawn(PrefabCode prefabCode, Vector3 position, Quaternion rotation);
    void Despawn(T instance);
}
