
using System.Collections.Generic;


public interface IPlanetRespawner
{
    List<string> PlanetList { get; }
    void SetPlanetList(List<string> PlanetList);
    PlanetCtrl PlanetCtrl { get; }
    float cooldownTime { get; }
    float cooldownTimer { get; }
    bool PlanetExist();
}