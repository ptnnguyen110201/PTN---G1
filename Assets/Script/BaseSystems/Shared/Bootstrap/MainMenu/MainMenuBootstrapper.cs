
using GameSystems.MainStationSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectName.Bootstrap
{
    public class MainMenuBootstrapper : IBootstrapper
    {
        public void Initialize()
        {
            UpdateBootstrap.Initialize();
            MainStationBootstrap.Initialize();
        }

    }
}
