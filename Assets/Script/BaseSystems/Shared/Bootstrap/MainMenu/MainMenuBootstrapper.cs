

using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBootstrapper : IBootstrapper
{

    public async Task Initialize()
    {

        DIContainer DIContainer = new DIContainer();
        GameContext.Instance.SetDIContainer(DIContainer);
        await SaveBootstrap.Initialize(DIContainer);
        await MainStationBootstrap.Initialize(DIContainer);
        await SubStationManagerBootstrap.Initialize(DIContainer);
        await PlanetManagerBootstrap.Initialize(DIContainer);
        await ShipResourceManagerBootstrap.Initialize(DIContainer);
        await PlanetPointManagerBootstrap.Initialize(DIContainer);


        SaveBootstrap.Initialize();
    }

}

