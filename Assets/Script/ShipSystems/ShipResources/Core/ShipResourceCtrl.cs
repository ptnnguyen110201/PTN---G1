
using System.Collections.Generic;
using UnityEngine;

public class ShipResourceCtrl : ShipCtrl
{
    public IShipResourceFactory ShipResourceFactory { get; private set; }
    public Dictionary<string, int> ResourceCollect { get; private set; } = new Dictionary<string, int>()
    {
        {"Gold", 5 }
    };
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





    public void SetResourceCollect(Dictionary<string, int> ResourceCollect) => this.ResourceCollect = new(ResourceCollect);

    public void SetPos(Transform TransferPos, Transform CollectPos)
    {
        this.TransferPos = TransferPos;
        this.CollectPos = CollectPos;
    }


}




