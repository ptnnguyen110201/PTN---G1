using UnityEngine;

public class Sub2 : SubStationCtrl
{
   
    public Sub2IFacotry Sub2IFacotry { get; private set; }
    public override void OnDespawn()
    {
       
    }

    public override void OnSpawn()
    {
        GameContext.Instance.Container.InjectInto(this);
        this.Sub2IFacotry = this.SubStationFactoryFactory.CreateFactory(this) as Sub2IFacotry;

    }

}