public interface IShipState <T> : IState where T : ShipCtrl
{
    T ShipObj { get; }
}