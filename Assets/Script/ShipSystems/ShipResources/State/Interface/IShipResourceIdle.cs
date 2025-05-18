public interface IShipResourceIdle : IShipState<ShipResourceCtrl>
{
    bool IsPlanetDepleted { get;}
    void SetDepleted(bool depleted);
}