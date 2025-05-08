using UnityEngine;

public abstract class ShipCtrl<T> : MonoBehaviour, IPoolable where T : ShipCtrl<T>
{
    public ISpawner<T> Spawner { get; set; }
    public abstract void OnSpawn();
    public abstract void OnDespawn();

    protected void DespawnSelf()
    {
        this.Spawner.Despawn(this as T);
    }
}
