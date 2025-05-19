using System;

public interface IShipFactoryFactory
{
    TFactory CreateFactory<TShip, TFactory>(TShip ship)
         where TShip : ShipCtrl
         where TFactory : class, IShipFactory, new();

    void ReleaseFactory(IShipFactory factory, ShipCtrl ship);
    void RegisterFactoryCreator<TShip>(Func<IShipFactory> creator) where TShip : ShipCtrl;
}

