using System.Collections.Generic;
using UnityEngine;

public class Sub1Factory : SubStationFactory, Sub1IFacotry
{
    public ICreateShip CreateShip { get; private set; }

    public override void Create(SubStationCtrl ObjT)
    {
        this.CreateShip = new Sub1CreateShip();
    }



    public override void Destroy()
    {
        
    }
}
