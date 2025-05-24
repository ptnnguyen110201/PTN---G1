
using System.Collections.Generic;
using UnityEngine;

public class ShipResourceCtrl : ShipCtrl
{
    [SerializeField] public ShipResourceData ShipResourceData;
    public IShipResourceFactory ShipResourceFactory { get; private set; }
    public Transform TransferPos { get; private set; }
    public Transform CollectPos { get; private set; }

    public override void OnDespawn()
    {
        this.ShipFactoryFactory.ReleaseFactory(this.ShipResourceFactory, this);
        this.ShipResourceFactory = null;
       
    }

    public override void OnSpawn()
    {
        GameContext.Instance.Container.InjectInto(this);
        this.ShipResourceFactory = this.CreateFactory<ShipResourceCtrl, ShipResourceFactory>(this);
    }





    public void SetShipResourceData(ShipResourceData shipResourceData) => this.ShipResourceData = shipResourceData;


    public void SetPos(Transform TransferPos, Transform CollectPos)
    {
        this.TransferPos = TransferPos;
        this.CollectPos = CollectPos;
    }


}




