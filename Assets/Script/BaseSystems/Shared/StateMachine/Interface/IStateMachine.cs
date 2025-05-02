using System;
using UnityEngine;

public interface IStateMachine 
{
    MonoBehaviour CoroutineRunner {  get; }
    Coroutine UpdateCoroutine { get; } 
    StatePool StatePool { get; }
    IState CurrentState { get; }
    void SetState<T>(Func<T> createState) where T : IState;
}
