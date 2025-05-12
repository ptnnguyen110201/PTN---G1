using System.Collections.Generic;

public interface IPlanetPointFactory: IFactory <PlanetPointCtrl>
{
    List<string> PlanetList { get; }
    void SetPlanetList(List<string> PlanetList);
    IPlanetRespawner PlanetRespawner { get; }

}
