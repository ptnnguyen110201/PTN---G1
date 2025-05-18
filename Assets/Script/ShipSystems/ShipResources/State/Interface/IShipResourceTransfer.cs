using System.Collections.Generic;

public interface IShipResourceTransfer : IShipState<ShipResourceCtrl>
{
    MainStationCtrl TransferStation { get; }
    bool IsPlanetDepleted { get; }
    void SetDepleted(bool depleted);
}