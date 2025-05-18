using System;
using System.Collections.Generic;

public class SubStationFactoryFactory : ISubStationFactoryFactory
{
    private readonly Dictionary<Type, Stack<ISubStationFactory>> _pools = new();
    private readonly Dictionary<Type, Func<ISubStationFactory>> _factoryCreators = new()
    {
        { typeof(Sub1), () => new Sub1Factory() },
        { typeof(Sub2), () => new Sub2Factory() },
    };

    public ISubStationFactory CreateFactory(SubStationCtrl subStation)
    {
        Type stationType = subStation.GetType();

        if (!_pools.ContainsKey(stationType))
        {
            _pools[stationType] = new Stack<ISubStationFactory>();
        }

        Stack<ISubStationFactory> pool = _pools[stationType];
        ISubStationFactory factory;

        if (pool.Count > 0)
        {
            factory = pool.Pop();
        }
        else
        {
            if (!_factoryCreators.ContainsKey(stationType))
                throw new Exception($"Factory creator not registered for {stationType.Name}");

            factory = _factoryCreators[stationType]();
        }

        factory.Create(subStation);
        return factory;
    }

    public void ReleaseFactory(ISubStationFactory factory, SubStationCtrl subStation)
    {
        factory.Destroy();
        Type stationType = subStation.GetType();

        if (!_pools.ContainsKey(stationType))
        {
            _pools[stationType] = new Stack<ISubStationFactory>();
        }

        _pools[stationType].Push(factory);
    }

    public void RegisterFactoryCreator<TSubStation>(Func<ISubStationFactory> creator) where TSubStation : SubStationCtrl
    {
        _factoryCreators[typeof(TSubStation)] = creator;
    }
}
