using UnityEngine;
using UnityEngine.EventSystems;

public class PlanetPickUp : IPlanetPickUp
{
    public IPlanetFactory PlanetFactory {  get; private set; }

    public PlanetPickUp(IPlanetFactory planetFactory)
    {
        this.PlanetFactory = planetFactory;
    }

    public void OnPlanetClick()
    {
       
       
    }

   
}