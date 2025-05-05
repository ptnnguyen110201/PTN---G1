
using GameSystems.MainStationSystem;
using UnityEngine;

namespace ProjectName.Bootstrap
{
    public class MainMenuBootstrapper : IBootstrapper
    {
        public void Initialize()
        {
            UpdateBootstrap.Initialize();

            DIContainer DIContainer = new DIContainer();
            GameContext.Instance.SetDIContainer(DIContainer);

            MainStationBootstrap.Initialize(DIContainer);

        }

    }
}
