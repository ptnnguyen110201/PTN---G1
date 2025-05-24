using System.Collections.Generic;
using UnityEngine;

public class Sub2Factory : SubStationFactory, Sub2IFacotry
{
   
    public override void Create(SubStationCtrl ObjT)
    {
        this.Create();
    }

    public void Create()
    {

    }

    public override void Destroy()
    {
        
    }
}
