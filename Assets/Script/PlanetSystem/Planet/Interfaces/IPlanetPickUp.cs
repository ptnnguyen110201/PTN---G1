using UnityEngine.EventSystems;

public interface IPlanetPickUp
{
    IPlanetFactory PlanetFactory { get; }
    void OnPlanetClick();

}