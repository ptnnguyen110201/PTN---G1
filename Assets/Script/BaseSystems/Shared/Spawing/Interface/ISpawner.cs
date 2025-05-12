
using UnityEngine;

public interface ISpawner<T> where T : Component, IPoolable
{
    void Preload(string prefabName, int preloadCount);
    T Spawn(string prefabName, Vector3 position, Quaternion rotation);
    void Despawn(T instance);
}
