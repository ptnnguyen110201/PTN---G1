using System.Collections.Generic;

public abstract class SubStationFactory : ISubStationFactory
{
    public abstract void Create(SubStationCtrl ObjT);

    public abstract void Destroy();


}
