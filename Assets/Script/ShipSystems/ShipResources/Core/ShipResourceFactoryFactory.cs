using System.Collections;
using System.Collections.Generic;

public class ShipResourceFactoryFactory : IShipResourceFactoryFactory
{
    protected Stack<IShipResourceFactory> IShipFactory = new Stack<IShipResourceFactory>();
    public IShipResourceFactory CreateFactory(ShipResourceCtrl ship)
    {
        IShipResourceFactory shipResourceFactory;

        if(this.IShipFactory.Count <= 0) shipResourceFactory = new ShipResourceFactory();
        else shipResourceFactory = this.IShipFactory.Pop();
        shipResourceFactory.Create(ship);
        return shipResourceFactory;
    }

    public void ReleaseFactory(IShipResourceFactory ShipResourceFactory)
    {
        ShipResourceFactory.Destroy();
        this.IShipFactory.Push(ShipResourceFactory);
    }
}
