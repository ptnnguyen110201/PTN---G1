public interface IShipResourceFactoryFactory
{
    IShipResourceFactory CreateFactory(ShipResourceCtrl ShipResourceCtrl);
    void ReleaseFactory(IShipResourceFactory ShipResourceFactory);
}
