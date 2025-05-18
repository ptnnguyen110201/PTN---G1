using UnityEngine;

public interface IShipResourceFactory : IFactory<ShipResourceCtrl>
{
    IStateMachine StateMachine { get; }
    IShipResourceInventory ShipResourceInventory { get; }
    IShipResourceLookat ShipResourceLookat { get; }
}