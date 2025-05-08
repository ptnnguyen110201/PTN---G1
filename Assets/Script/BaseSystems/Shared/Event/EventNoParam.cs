using System;
public class EventNoParam : BaseEvent
{
    private Action _action;

    public void Subscribe(Action listener)
    {
        _action += listener;
    }

    public void Unsubscribe(Action listener)
    {
        _action -= listener;
    }

    public void Invoke()
    {
        _action?.Invoke();
    }

    public override void Clear()
    {
        _action = null;
    }
}

