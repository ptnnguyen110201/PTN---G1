using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlanetPointSpawner : Spawner<PlanetPointCtrl>, IPlanetPointSpawner
{
    public PlanetPointSpawner(IPlanetPointPrefab prefabLoader) : base(prefabLoader)
    {


    }

    public Task SpawnPlanetPoint()
    {
        IPlanetPointManager planetPointManager = GameContext.Instance.Container.Resolve<IPlanetPointManager>();

        foreach (var kvp in planetPointManager.PlanetPointPosReader.SpawnPosMap) 
        {
            PlanetPointCtrl planetPointCtrl = this.Spawn("PlanetPoint", kvp.Value.SpawnPoint, Quaternion.identity);
            planetPointCtrl.PlanetPointFactory.PlanetRespawner.SetPlanetList(kvp.Value.PlanetList);
        }
        
        return Task.CompletedTask;
    }
}