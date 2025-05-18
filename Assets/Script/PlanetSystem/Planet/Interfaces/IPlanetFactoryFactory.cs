public interface IPlanetFactoryFactory
{
    IPlanetFactory CreateFactory(PlanetCtrl PlanetCtrl);
    void ReleaseFactory(IPlanetFactory IPlanetFactory);
}
