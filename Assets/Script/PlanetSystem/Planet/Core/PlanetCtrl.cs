using UnityEngine;

public class PlanetCtrl : MonoBehaviour, IPoolable
{
    public ISpawner<PlanetCtrl> Spawner { get; set; }
    public void OnDespawn()
    {
  
    }

    public void OnSpawn()
    {

    }
    protected void DespawnSelf()
    {
        this.Spawner.Despawn(this);
    }
}
