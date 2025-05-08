

using UnityEngine;
using UnityEngine.UI;

public class MainMenuBootstrapper : IBootstrapper
{
    public void Initialize()
    {
        UpdateBootstrap.Initialize();

        DIContainer DIContainer = new DIContainer();
        GameContext.Instance.SetDIContainer(DIContainer);

        MainStationBootstrap.Initialize(DIContainer);
        ShipManagerBootstrap.Initialize(DIContainer);



       
    }

}

