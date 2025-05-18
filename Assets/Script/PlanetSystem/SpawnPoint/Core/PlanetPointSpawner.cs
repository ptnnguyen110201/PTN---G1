using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlanetPointSpawner : Spawner<PlanetPointCtrl>, IPlanetPointSpawner
{   public IPlanetPointFactoryFactory PlanetPointFactoryFactory { get; private set; }
    public PlanetPointSpawner(IPlanetPointPrefab prefabLoader, IPlanetPointFactoryFactory IPlanetPointFactoryFactory) : base(prefabLoader)
    {
        this.PlanetPointFactoryFactory = IPlanetPointFactoryFactory;

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