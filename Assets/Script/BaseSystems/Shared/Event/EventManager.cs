using System;
using System.Collections.Generic;

public static class EventManager
{
    private static readonly Dictionary<string, BaseEvent> _events = new();
    public static void Subscribe(string eventName, Action listener)
    {
        if (!_events.TryGetValue(eventName, out BaseEvent baseEvent))
        {
            baseEvent = new EventNoParam();
            _events.Add(eventName, baseEvent);
        }

        (baseEvent as EventNoParam)?.Subscribe(listener);
    }


    public static void Subscribe<T>(string eventName, Action<T> listener)
    {
        if (!_events.TryGetValue(eventName, out BaseEvent baseEvent))
        {
            baseEvent = new EventOneParam<T>();
            _events.Add(eventName, baseEvent);
        }

        (baseEvent as EventOneParam<T>)?.Subscribe(listener);
    }


    public static void Subscribe<T1, T2>(string eventName, Action<T1, T2> listener)
    {
        if (!_events.TryGetValue(eventName, out BaseEvent baseEvent))
        {
            baseEvent = new EventTwoParams<T1, T2>();
            _events.Add(eventName, baseEvent);
        }

        (baseEvent as EventTwoParams<T1, T2>)?.Subscribe(listener);
    }




    public static void Unsubscribe(string eventName)
    {
        if (_events.ContainsKey(eventName))
        {
            _events[eventName].Clear();
            _events.Remove(eventName);
        }
    }


    public static void Invoke(string eventName)
    {
        if (_events.TryGetValue(eventName, out BaseEvent baseEvent))
        {
            (baseEvent as EventNoParam)?.Invoke();
        }
    }


    public static void Invoke<T>(string eventName, T param)
    {
        if (_events.TryGetValue(eventName, out BaseEvent baseEvent))
        {
            (baseEvent as EventOneParam<T>)?.Invoke(param);
        }
    }


    public static void Invoke<T1, T2>(string eventName, T1 param1, T2 param2)
    {
        if (_events.TryGetValue(eventName, out BaseEvent baseEvent))
        {
            (baseEvent as EventTwoParams<T1, T2>)?.Invoke(param1, param2);
        }
    }



    public static void ClearAll()
    {
        foreach (var kvp in _events)
        {
            kvp.Value.Clear();
        }
        _events.Clear();
    }
}

