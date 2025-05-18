using UnityEngine;

public interface IShipResourceLookat : IShipLookat<ShipResourceCtrl>
{
    Transform ObjLookat { get; }
    void SetObjLookat(Transform ObjLookat);
}