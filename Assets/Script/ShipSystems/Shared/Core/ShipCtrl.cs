using UnityEngine;

public abstract class ShipCtrl : MonoBehaviour, IPoolable
{
    public virtual void OnDespawn()
    {

    }

    public virtual void OnSpawn()
    {
      
    }
}