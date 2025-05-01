using UnityEngine;

namespace GameSystems.Shared.SystemBase
{
    public static class BaseBootstrap
    {

        public static TInstaller AttachInstaller<TInstaller>(bool DontDestroy = false) where TInstaller : Component
        {
            GameObject installerObject = new GameObject(typeof(TInstaller).Name);
            TInstaller installer = installerObject.AddComponent<TInstaller>();
            if (DontDestroy)
            {
                Object.DontDestroyOnLoad(installer);
            }
            return installer;
        }

    }
}