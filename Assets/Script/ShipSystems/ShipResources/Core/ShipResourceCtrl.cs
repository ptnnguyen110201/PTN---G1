
using System.Collections.Generic;
using UnityEngine;

public class ShipResourceCtrl : ShipCtrl<ShipResourceCtrl>
{
    [Inject] IShipResourceFactoryFactory ShipResourceFactoryFactory;  
    public IShipResourceFactory ShipResourceFactory { get; private set; }
    public Dictionary<string, int> ResourceCollect { get; private set; } = new Dictionary<string, int>()
    {
        {"Gold", 5 }
    };
    public Transform TransferPos { get; private set; }
    public Transform CollectPos { get; private set; }

    public override void OnDespawn()
    {
        this.ShipResourceFactoryFactory.ReleaseFactory(this.ShipResourceFactory);
        this.ShipResourceFactory = null;
       
    }

    public override void OnSpawn()
    {
        GameContext.Instance.Container.InjectInto(this);
        this.ShipResourceFactory = this.ShipResourceFactoryFactory.CreateFactory(this);
    }





    public void SetResourceCollect(Dictionary<string, int> ResourceCollect) => this.ResourceCollect = new(ResourceCollect);

    public void SetPos(Transform TransferPos, Transform CollectPos)
    {
        this.TransferPos = TransferPos;
        this.CollectPos = CollectPos;
    }


}




