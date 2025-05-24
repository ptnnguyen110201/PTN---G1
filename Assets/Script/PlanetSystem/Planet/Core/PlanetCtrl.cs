using UnityEngine;
using UnityEngine.EventSystems;

public class PlanetCtrl : MonoBehaviour, IPoolable, IPointerDownHandler

{   [Inject] IShipResourceSender ShipResourceSender;
    [Inject] IPlanetFactoryFactory PlanetFactoryFactory;
    public IPlanetFactory PlanetFactory;
  
    public void OnDespawn()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.ShipResourceSender.SendShip("Ship1", this.transform);
        this.ShipResourceSender.SendShip("Ship2", this.transform);
        this.ShipResourceSender.SendShip("Ship3", this.transform);
    }

    public void OnSpawn()
    {
        GameContext.Instance.Container.InjectInto(this);
        this.PlanetFactory = this.PlanetFactoryFactory.CreateFactory(this);


    }
}
