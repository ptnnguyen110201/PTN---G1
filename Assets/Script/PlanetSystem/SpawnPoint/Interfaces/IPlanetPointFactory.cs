using System.Collections.Generic;

public interface IPlanetPointFactory: IFactory <PlanetPointCtrl>
{
  
    IPlanetRespawner PlanetRespawner { get; }

}
