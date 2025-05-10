

using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBootstrapper : IBootstrapper
{
    
    public async Task Initialize()
    {
        UpdateBootstrap.Initialize();

        DIContainer DIContainer = new DIContainer();
        GameContext.Instance.SetDIContainer(DIContainer);

        await MainStationBootstrap.Initialize(DIContainer);
        await ShipManagerBootstrap.Initialize(DIContainer);
        await PlanetManagerBootstrap.Initialize(DIContainer);
        await PlanetSpawnPointManagerBootstrap.Initialize(DIContainer);
    }

}

