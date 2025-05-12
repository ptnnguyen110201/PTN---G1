using System.Threading.Tasks;
using UnityEngine;

public class PlanetManagerInstaller : GameSystemInstaller
{
    public override Task Install(DIContainer container)
    {

        container.Bind<IPlanetPrefabLoader, PlanetPrefabLoader>();
        container.Bind<IPlanetSpawner, PlanetSpawner>();
        container.Bind<IPlanetManager, PlanetManager>();
        return Task.CompletedTask;
      
    }
   
}
