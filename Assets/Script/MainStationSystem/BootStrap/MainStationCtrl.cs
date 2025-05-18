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
    protected void Update()
    {
        foreach(var kvp in this.MainStation.MainStationStorage.ResourceMap) 
        {
            string resourceType = kvp.Key;
            int amount = kvp.Value;
            Debug.Log($"Resource Type: {resourceType}, Amount: {amount}");
        }
    }



}

