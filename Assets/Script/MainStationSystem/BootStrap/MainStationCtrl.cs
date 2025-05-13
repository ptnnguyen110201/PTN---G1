using UnityEngine;

public class MainStationCtrl : MonoBehaviour, IMainStationCtrl, IPoolable
{
    public Transform MainStationPos { get; private set; }
    public IMainStation MainStation { get; private set; }

    public void OnDespawn()
    {
     
    }

    public void OnSpawn()
    {
       
        this.MainStationPos = this.transform;
        this.MainStation = GameContext.Instance.Container.Resolve<IMainStation>();
    }

}

