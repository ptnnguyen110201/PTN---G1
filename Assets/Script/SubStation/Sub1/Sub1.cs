using UnityEngine;
using UnityEngine.UIElements;

public class Sub1 : SubStationCtrl
{

    public Sub1IFacotry Sub1IFacotry { get; private set; }

    public override void OnDespawn()
    {
    
    }

    public override void OnSpawn()
    {
        GameContext.Instance.Container.InjectInto(this);
        this.Sub1IFacotry = this.CreateFactory<Sub1, Sub1Factory>(this);


    }
}