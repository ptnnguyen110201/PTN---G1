using UnityEngine;

public abstract class SubStationCtrl: MonoBehaviour, IPoolable
{
    [Inject] protected IMainStationCtrl MainStationCtrl;
    [Inject] protected ISubStationFactoryFactory SubStationFactoryFactory;

    protected TSubFactory CreateFactory<TSubCtrl, TSubFactory>(TSubCtrl subCtrl)
       where TSubCtrl : SubStationCtrl
       where TSubFactory : class, ISubStationFactory, new()
    {
        return this.SubStationFactoryFactory.CreateFactory<TSubCtrl, TSubFactory>(subCtrl);
    }
    public abstract void OnDespawn();
    public abstract void OnSpawn();
     
}   