using UnityEngine;

public abstract class ShipCtrl<T> : MonoBehaviour, IPoolable where T : ShipCtrl<T>
{
    protected ISpawner<T> Spawner { get; private set; }
    public void InjectSpawner(ISpawner<T> spawner) => this.Spawner = spawner; 
    public void DespawnSelf()
    {
        this.Spawner.Despawn(this as T);
    }
    public abstract void OnSpawn();
    public abstract void OnDespawn();

   
}
