using UnityEngine;

public abstract class ShipLookat<T> : IShipLookat<T> where T : ShipCtrl<T>
{
    public T ShipObj { get; private set; }
    public ShipLookat(T shipObj)
    {
        this.ShipObj = shipObj;
    }
    public abstract void LookAt(Transform target);
}
