using UnityEngine;

public interface IShipLookat<T> 
{
    T ShipObj { get; }
    void LookAt(Transform target);
}