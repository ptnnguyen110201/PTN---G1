using UnityEngine;

public class ShipResourceFactory : IShipResourceFactory
{
    public IStateMachine StateMachine { get; private set; }

    public Transform TransferPos { get; private set; }

    public Transform CollectPos { get; private set; }

    public ShipResourceCtrl ObjT {  get; private set; }

    public void Create(ShipResourceCtrl ObjT)
    {
        this.ObjT = ObjT;
        this.StateMachine = new StateMachine(ObjT);
    }

    public void Pos(Transform TransferPos, Transform CollectPos)
    {
        this.TransferPos = TransferPos;
        this.CollectPos = CollectPos;

    }
}