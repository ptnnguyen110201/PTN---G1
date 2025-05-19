using System;
using System.Collections.Generic;

public class ShipFactoryFactory : IShipFactoryFactory
{
    private readonly Dictionary<Type, Stack<IShipFactory>> shipFactories = new();
    private readonly Dictionary<Type, Func<IShipFactory>> factoryCreators = new();

    public void RegisterFactoryCreator<TShip>(Func<IShipFactory> creator)
        where TShip : ShipCtrl
    {
        this.factoryCreators[typeof(TShip)] = creator;
    }

    public TFactory CreateFactory<TShip, TFactory>(TShip ship)
        where TShip : ShipCtrl
        where TFactory : class, IShipFactory, new()
    {
        Type shipType = typeof(TShip);

        if (!this.shipFactories.ContainsKey(shipType))
        {
            this.shipFactories[shipType] = new Stack<IShipFactory>();
        }

        Stack<IShipFactory> pool = this.shipFactories[shipType];

        IShipFactory factory = pool.Count > 0
            ? pool.Pop()
            : this.factoryCreators.TryGetValue(shipType, out var creator)
                ? creator()
                : new TFactory();

        factory.Create(ship);
        return factory as TFactory;
    }

    public void ReleaseFactory(IShipFactory factory, ShipCtrl ship)
    {
        factory.Destroy();
        Type shipType = ship.GetType();

        if (!this.shipFactories.ContainsKey(shipType))
        {
            this.shipFactories[shipType] = new Stack<IShipFactory>();
        }

        this.shipFactories[shipType].Push(factory);
    }
}