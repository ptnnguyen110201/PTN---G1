
using UnityEngine;
namespace GameSystems.Shared.SystemBase
{
    public abstract class BaseGameSystem<T> where T : class
    {
        public abstract void Initialize();

        protected void Log(string message)
        {
            Debug.Log($"[{typeof(T).Name}] {message}");
        }
    }
}