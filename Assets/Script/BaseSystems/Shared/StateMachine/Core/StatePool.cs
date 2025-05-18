using System;
using System.Collections.Generic;

public class StatePool
{
    private readonly Dictionary<Type, IState> cache = new();

    public T GetState<T>(Func<T> createFunc = null) where T : IState
    {
        Type type = typeof(T);

        if (!this.cache.TryGetValue(type, out IState state))
        {
            if (createFunc == null)
                throw new Exception($"State of type {type} not created yet and no createFunc provided.");

            state = createFunc();
            this.cache[type] = state;
        }

        return (T)state;
    }

    public void Clear() => cache.Clear();
}
