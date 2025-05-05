using UnityEngine;

namespace GameSystems.Shared.SystemBase
{
    public abstract class BaseInstaller<T> : MonoBehaviour where T : class, IInitializableSystem
    {
        public static T Instance { get; protected set; }

        protected virtual void Awake()
        {
            Instance = this.CreateSystem();
            Instance.Initialize();

        }

        public abstract T CreateSystem();
    }
}