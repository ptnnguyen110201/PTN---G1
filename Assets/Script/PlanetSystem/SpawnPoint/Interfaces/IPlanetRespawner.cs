
using System.Collections.Generic;


public interface IPlanetRespawner
{
    PlanetPointCtrl PlanetPointCtrl { get; }
    PlanetCtrl PlanetCtrl { get; }
    float cooldownTime { get; }
    float cooldownTimer { get; }
    bool PlanetExist();
}