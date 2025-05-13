using UnityEngine;
using UnityEngine.EventSystems;

public class PlanetCtrl : MonoBehaviour, IPoolable
{
    public PlanetUpdater PlanetUpdater;
    public IPlanetFactory PlanetFactory;
    public void OnDespawn()
    {

    }
    public void OnSpawn()
    {
        this.PlanetUpdater = new PlanetUpdater(this);
        this.PlanetFactory = new PlanetFactory();
        this.PlanetFactory.Create(this);

    }
}
