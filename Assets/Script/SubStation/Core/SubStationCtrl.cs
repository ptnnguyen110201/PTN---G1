using UnityEngine;

public abstract class SubStationCtrl: MonoBehaviour, IPoolable
{
    [Inject] protected IMainStationCtrl MainStationCtrl;
    [Inject] protected ISubStationFactoryFactory SubStationFactoryFactory;
  
    public abstract void OnDespawn();
    public abstract void OnSpawn();

}   