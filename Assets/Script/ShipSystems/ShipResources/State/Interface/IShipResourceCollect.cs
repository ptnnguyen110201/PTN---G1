using System.Collections.Generic;

public interface IShipResourceCollect : IShipState<ShipResourceCtrl>
{
    Dictionary<string, int> ResourceCollect { get; }
    PlanetCtrl CollectPlanet { get; }

 
}