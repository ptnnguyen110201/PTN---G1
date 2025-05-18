using UnityEngine;

public interface IShipResourceMove : IShipState<ShipResourceCtrl>
{
    Transform Target { get; }
    bool IsFull { get;  }
    void SetFull(bool full);
    bool IsPlanetDepleted { get; }
    void SetDepleted(bool depleted);
}