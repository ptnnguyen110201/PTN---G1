using System.Threading.Tasks;
using UnityEngine;

public class PlanetManagerInstaller : GameSystemInstaller
{
    public override async Task Install(DIContainer container)
    {
        PlanetPrefabLoader PlanetPrefabLoader = new();
        await PlanetPrefabLoader.LoadPrefabs();

        container.Bind<IPlanetPrefabLoader>(() => PlanetPrefabLoader);
        container.Bind<IPlanetSpawner>(() => new PlanetSpawner(PlanetPrefabLoader));
        container.Bind<IPlanetManager, PlanetManager>();

       
    }
   
}
