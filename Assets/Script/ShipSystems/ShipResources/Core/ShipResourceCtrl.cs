
using UnityEngine;

public class ShipResourceCtrl : ShipCtrl<ShipResourceCtrl>
{

    public IShipResourceFactory ShipResourceFactory { get; private set; }

    public override void OnDespawn()
    {
       
    }

    public override void OnSpawn()
    {
        this.ShipResourceFactory = new ShipResourceFactory();
        this.ShipResourceFactory.Create(this);
    }


 

}




