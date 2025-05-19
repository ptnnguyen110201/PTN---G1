using System.Collections.Generic;

public abstract class ShipFactory : IShipFactory
{
    public abstract void Create(ShipCtrl ObjT);

    public abstract void Destroy();


}
