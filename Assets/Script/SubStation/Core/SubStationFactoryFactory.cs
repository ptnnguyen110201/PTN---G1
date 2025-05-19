using System;
using System.Collections.Generic;


public class SubStationFactoryFactory : ISubStationFactoryFactory
{
    private readonly Dictionary<Type, Stack<ISubStationFactory>> StationFactory = new();
    private readonly Dictionary<Type, Func<ISubStationFactory>> FactoryCreator = new();

    public void RegisterFactoryCreator<TStation>(Func<ISubStationFactory> creator)
        where TStation : SubStationCtrl
    {
        this.FactoryCreator[typeof(TStation)] = creator;
    }

    public TFactory CreateFactory<TStation, TFactory>(TStation station)
        where TStation : SubStationCtrl
        where TFactory : class, ISubStationFactory, new()
    {
        Type stationType = typeof(TStation);

        if (!this.StationFactory.ContainsKey(stationType))
        {
            this.StationFactory[stationType] = new Stack<ISubStationFactory>();
        }

        Stack<ISubStationFactory> pool = this.StationFactory[stationType];

        ISubStationFactory factory = pool.Count > 0
            ? pool.Pop()
            : this.FactoryCreator.TryGetValue(stationType, out var creator)
                ? creator()
                : new TFactory();

        factory.Create(station);
        return factory as TFactory;
    }

    public void ReleaseFactory(ISubStationFactory factory, SubStationCtrl station)
    {
        factory.Destroy();
        Type stationType = station.GetType();

        if (!this.StationFactory.ContainsKey(stationType))
        {
            this.StationFactory[stationType] = new Stack<ISubStationFactory>();
        }

        this.StationFactory[stationType].Push(factory);
    }

}
