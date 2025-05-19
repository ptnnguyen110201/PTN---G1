using UnityEngine;

public abstract class ShipCtrl : MonoBehaviour, IPoolable
{
    [Inject] protected IShipFactoryFactory ShipFactoryFactory;
    protected TShipFactory CreateFactory<TShipCtrl, TShipFactory>(TShipCtrl ShipCtrl)
   where TShipCtrl : ShipCtrl
   where TShipFactory : class, IShipFactory, new()
    {
        return this.ShipFactoryFactory.CreateFactory<TShipCtrl, TShipFactory>(ShipCtrl);
    }
    public abstract void OnSpawn();
    public abstract void OnDespawn();


}
