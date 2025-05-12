using System.Collections.Generic;
using UnityEngine;

public class PlanetPointSpawner : Spawner<PlanetPointCtrl>, IPlanetPointSpawner
{
    public PlanetPointSpawner(IPlanetPointPrefab prefabLoader) : base(prefabLoader)
    {
        

    }

  
}