using System;

public interface ISubStationFactoryFactory
{
    TFactory CreateFactory<TStation, TFactory>(TStation station)
         where TStation : SubStationCtrl
         where TFactory : class, ISubStationFactory, new();

    void ReleaseFactory(ISubStationFactory factory, SubStationCtrl station);
    void RegisterFactoryCreator<TStation>(Func<ISubStationFactory> creator) where TStation : SubStationCtrl;
}
