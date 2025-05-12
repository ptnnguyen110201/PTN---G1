using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component, IPoolable
{
    private readonly T prefab;
    private readonly Transform parent;
    private readonly Stack<T> poolStack = new();

    public ObjectPool(T prefab, Transform parent = null)
    {
        this.prefab = prefab;
        this.parent = parent;
    }

    public void Preload(int count)
    {
        for (int i = 0; i < count; i++)
        {
            T instance = InstantiateNewObject();
            instance.gameObject.SetActive(false);
            poolStack.Push(instance);
        }
    }

    private T InstantiateNewObject()
    {
        T instance = GameObject.Instantiate(this.prefab, this.parent);
        instance.gameObject.name = this.prefab.name;
        instance.gameObject.SetActive(false);
        return instance;
    }

    public T Spawn(Vector3 position, Quaternion rotation)
    {
        T instance = this.poolStack.Count > 0 ? this.poolStack.Pop() : this.InstantiateNewObject();

        instance.transform.position = position;
        instance.transform.rotation = rotation;  
        instance.gameObject.SetActive(true);
        instance.OnSpawn();
       
     
        return instance;
    }

    public void Despawn(T instance)
    {
        instance.OnDespawn();
        instance.gameObject.SetActive(false);
        this.poolStack.Push(instance);
    }
}
