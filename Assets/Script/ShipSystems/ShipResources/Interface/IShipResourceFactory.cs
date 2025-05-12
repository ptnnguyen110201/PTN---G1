using UnityEngine;

public interface IShipResourceFactory : IFactory<ShipResourceCtrl>
{
    IStateMachine StateMachine { get; }
    Transform TransferPos { get; }
    Transform CollectPos { get; }

    void Pos(Transform TransferPos, Transform CollectPos);
}