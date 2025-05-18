public interface IPlanetPointFactoryFactory
{
    IPlanetPointFactory CreateFactory(PlanetPointCtrl PlanetPointCtrl);
    void ReleaseFactory(IPlanetPointFactory IPlanetFactory);
}
