using System;
using System.Collections;
using UnityEngine;

public class StateMachine : IStateMachine
{
    public IState CurrentState { get; private set; }
    public MonoBehaviour CoroutineRunner { get; private set; }
    public Coroutine UpdateCoroutine { get; private set; }
    public StatePool StatePool { get; private set; }

    public StateMachine(MonoBehaviour runner)
    {
        this.CoroutineRunner = runner;
        this.StatePool = new StatePool();
    }

    public void SetState<T>(Func<T> createState) where T : IState
    {
        if (this.CurrentState != null)
        {
            IEnumerator exitRoutine = this.CurrentState.OnExit();
            if (exitRoutine != null) CoroutineRunner.StartCoroutine(exitRoutine);
        }

        this.CurrentState = this.StatePool.GetState(createState);

        if (this.UpdateCoroutine != null)
        {
            CoroutineRunner.StopCoroutine(this.UpdateCoroutine);
        }

        IEnumerator enterRoutine = this.CurrentState.OnEnter();
        if (enterRoutine != null) CoroutineRunner.StartCoroutine(enterRoutine);

        this.UpdateCoroutine = CoroutineRunner.StartCoroutine(StateUpdateLoop());
    }

    private IEnumerator StateUpdateLoop()
    {
        while (this.CurrentState != null)
        {
            yield return this.CurrentState.OnUpdate();
            yield return null;
        }
    }
}
