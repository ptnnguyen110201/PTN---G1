using UnityEngine;

public interface IShipResourceFactory : IShipFactory
{
    IShipResourceSpawner ShipResourceSpanwer { get; }
    IStateMachine StateMachine { get; }
    IShipResourceInventory ShipResourceInventory { get; }
    IShipResourceLookat ShipResourceLookat { get; }
}