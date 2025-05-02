using System;
using System.Collections.Generic;

public class StatePool : IStatePool
{
    public Dictionary<Type, IState> PooledStates { get; private set; }
    public StatePool (Dictionary<Type, IState> pooledStates) 
    {
        this.PooledStates = pooledStates;
    }

    public T GetState<T>(Func<T> createState) where T : IState
    {
        Type type = typeof(T);

        if (!this.PooledStates.ContainsKey(type))
        {
            this.PooledStates[type] = createState();
        }

        return (T)this.PooledStates[type];
    }
    public void Clear()
    {
        this.PooledStates.Clear();
    }
}
