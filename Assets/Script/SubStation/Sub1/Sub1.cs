using UnityEngine;
using UnityEngine.UIElements;

public class Sub1 : SubStationCtrl
{

    public Sub1IFacotry sub1IFacotry { get; private set; }

    public override void OnDespawn()
    {
    
    }

    public override void OnSpawn()
    {
        GameContext.Instance.Container.InjectInto(this);
        this.sub1IFacotry = this.SubStationFactoryFactory.CreateFactory(this) as Sub1IFacotry;


    }
}