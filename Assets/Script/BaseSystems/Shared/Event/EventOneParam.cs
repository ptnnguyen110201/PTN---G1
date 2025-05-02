using System;

namespace GameSystems.Shared.Events
{
    public class EventOneParam<T> : BaseEvent
    {
        private Action<T> _action;

        public void Subscribe(Action<T> listener)
        {
            _action += listener;
        }

        public void Unsubscribe(Action<T> listener)
        {
            _action -= listener;
        }

        public void Invoke(T param)
        {
            _action?.Invoke(param);
        }

        public override void Clear()
        {
            _action = null;
        }
    }
}
