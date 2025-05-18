
using System.Threading.Tasks;
using UnityEngine;

public interface ISpawner<T> : IInitializableSystem where T : Component, IPoolable
{
    Task Preload(string prefabName, int preloadCount);
    T Spawn(string prefabName, Vector3 position, Quaternion rotation);
    void Despawn(T instance);
}
