using System;
using System.Collections.Generic;


public interface IStatePool
{
    Dictionary<Type, IState> PooledStates {  get; }
}
