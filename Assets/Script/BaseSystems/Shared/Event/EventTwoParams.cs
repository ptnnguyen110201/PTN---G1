using System;


public class EventTwoParams<T1, T2> : BaseEvent
{
    private Action<T1, T2> _action;

    public void Subscribe(Action<T1, T2> listener)
    {
        _action += listener;
    }

    public void Unsubscribe(Action<T1, T2> listener)
    {
        _action -= listener;
    }

    public void Invoke(T1 param1, T2 param2)
    {
        _action?.Invoke(param1, param2);
    }

    public override void Clear()
    {
        _action = null;
    }
}

