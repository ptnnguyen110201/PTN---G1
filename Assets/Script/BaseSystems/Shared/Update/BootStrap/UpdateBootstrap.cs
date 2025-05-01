using UnityEngine;
using GameSystems.Shared.SystemBase;
using GameSystems.Shared.Interfaces.Installer;


namespace GameSystems.MainStationSystem
{
    public static class UpdateBootstrap
    {
        public static void Initialize()
        {
            BaseBootstrap.AttachInstaller<UpdateInstaller>(false);
        }
     
    }
}
