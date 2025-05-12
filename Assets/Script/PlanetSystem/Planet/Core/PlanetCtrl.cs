using UnityEngine;
using UnityEngine.EventSystems;

public class PlanetCtrl : MonoBehaviour, IPoolable, IPointerDownHandler
{

    public IPlanetFactory PlanetFactory;
    public ISpawner<PlanetCtrl> Spawner { get; set; }
    public void OnDespawn()
    {

    }
    public void OnSpawn()
    {

        this.PlanetFactory = new PlanetFactory();
        this.PlanetFactory.Create(this);

    }

    protected void Start()
    {

        Invoke(nameof(Test), 1f);
    }


    void Test() 
    {
        this.PlanetFactory = new PlanetFactory();
        this.PlanetFactory.Create(this);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        this.PlanetFactory.PlanetPickUp.OnPlanetClick();
    }

    protected void DespawnSelf()
    {
        this.Spawner.Despawn(this);
    }
}
