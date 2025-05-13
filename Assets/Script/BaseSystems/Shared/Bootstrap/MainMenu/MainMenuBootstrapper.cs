

using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBootstrapper : IBootstrapper
{
    
    public async Task Initialize()
    {

        DIContainer DIContainer = new DIContainer();
        GameContext.Instance.SetDIContainer(DIContainer);

        await MainStationBootstrap.Initialize(DIContainer);    
        await PlanetManagerBootstrap.Initialize(DIContainer);
        await ShipManagerBootstrap.Initialize(DIContainer);
        await PlanetPointManagerBootstrap.Initialize(DIContainer);
     
    }

}

