public interface IShipState <T> : IState where T : ShipCtrl<T>
{
    T ShipObj { get; }
}