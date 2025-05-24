using NUnit.Framework;
using UnityEngine;

public class MainStationCtrl : MonoBehaviour, IMainStationCtrl, IPoolable
{
    [Inject] public IMainStation MainStation;
    public MainStationCtrl mainStationCtrl { get; private set; }

    
    public void OnDespawn()
    {
     
    }

    public void OnSpawn()
    {
        GameContext.Instance.Container.InjectInto(this);
        this.mainStationCtrl = this;
    }
   



}

