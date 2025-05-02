using System;
using System.Collections;
using UnityEngine;

public class StateMachine : IStateMachine
{
    public MonoBehaviour CoroutineRunner { get; private set; }  
    public Coroutine UpdateCoroutine { get; private set; }  
    public StatePool StatePool { get; private set; }
    public IState CurrentState { get; private set; }


    public StateMachine(MonoBehaviour runner)
    {
        this.CoroutineRunner = runner;
        this.StatePool = new StatePool(new());
    }
    public void SetState<T>(Func<T> createState) where T : IState
    {
        if (this.CurrentState != null)
        {
            this.CoroutineRunner.StartCoroutine(this.CurrentState.OnExit());
        }

        this.CurrentState = StatePool.GetState(createState);

        if (this.CurrentState != null)
        {
            this.CoroutineRunner.StartCoroutine(this.CurrentState.OnEnter());

            if (this.UpdateCoroutine != null)
            {
                this.CoroutineRunner.StopCoroutine(this.UpdateCoroutine);
            }
            this.UpdateCoroutine = this.CoroutineRunner.StartCoroutine(StateUpdateLoop());
        }
    }

    private IEnumerator StateUpdateLoop()
    {
        while (this.CurrentState != null)
        {
            yield return this.CurrentState.OnUpdate();
        }
    }

   
}
