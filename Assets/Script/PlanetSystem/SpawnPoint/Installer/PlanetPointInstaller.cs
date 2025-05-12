using System.Threading.Tasks;
using UnityEngine;

public class PlanetPointInstaller : GameSystemInstaller
{
    public override Task Install(DIContainer container)
    {
        container.Bind<IPlanetPointPosReader, PlanetPointPosReader>();
        container.Bind<IPlanetPointPrefab, PlanetPointPrefab>();
        container.Bind<IPlanetPointSpawner, PlanetPointSpawner>();
        container.Bind<IPlanetPointManager, PlanetPointManager>();
        return Task.CompletedTask;

    }
}
