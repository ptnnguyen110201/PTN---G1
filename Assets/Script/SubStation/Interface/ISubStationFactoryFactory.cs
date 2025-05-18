public interface ISubStationFactoryFactory
{
    ISubStationFactory CreateFactory( SubStationCtrl SubStation);
    void ReleaseFactory(ISubStationFactory SubStationFactory, SubStationCtrl subStation);
}
