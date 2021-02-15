using System;

namespace UniAgile.Observable
{
    public class Signal : ISignal
    {
        private event Action Event;
        public Delegate      Delegate => Event;

        public void AddListener(Action listener)
        {
            // this is the only consistent way for avoiding duplicates
            Event -= listener;
            Event += listener;
        }

        public void RemoveListener(Action listener)
        {
            Event -= listener;
        }

        public void Invoke()
        {
            Event?.Invoke();
        }

        public void RemoveAllListeners()
        {
            Event = delegate { };
        }
    }

    public class Signal<T1> : ISignal<T1>
    {
        private event Action<T1> Event;
        private event Action     ParameterlessEvent;
        public Delegate          Delegate => Event;

        public void RemoveAllListeners()
        {
            Event              = null;
            ParameterlessEvent = null;
        }

        public void AddListener(Action<T1> listener)
        {
            // this is the only consistent way for avoiding duplicates
            Event -= listener;
            Event += listener;
        }

        public void RemoveListener(Action<T1> listener)
        {
            Event -= listener;
        }

        public void Invoke(T1 param)
        {
            Event?.Invoke(param);
            ParameterlessEvent?.Invoke();
        }

        public void RemoveListener(Action listener)
        {
            ParameterlessEvent -= listener;
        }

        public void AddListener(Action listener)
        {
            ParameterlessEvent -= listener;
            ParameterlessEvent += listener;
        }
    }

    public class Signal<T1, T2> : ISignal<T1, T2>
    {
        private event Action<T1, T2> Event;

        private event Action ParameterlessEvent;
        public Delegate      Delegate => Event;

        public void AddListener(Action<T1, T2> listener)
        {
            // this is the only consistent way for avoiding duplicates
            Event -= listener;
            Event += listener;
        }

        public void RemoveListener(Action<T1, T2> listener)
        {
            Event -= listener;
        }

        public void Invoke(T1 param1,
                           T2 param2)
        {
            Event?.Invoke(param1, param2);
            ParameterlessEvent?.Invoke();
        }

        public void RemoveListener(Action listener)
        {
            ParameterlessEvent -= listener;
        }

        public void AddListener(Action listener)
        {
            ParameterlessEvent -= listener;
            ParameterlessEvent += listener;
        }

        public void RemoveAllListeners()
        {
            Event              = null;
            ParameterlessEvent = null;
        }
    }

    public class Signal<T1, T2, T3> : ISignal<T1, T2, T3>
    {
        private event Action<T1, T2, T3> Event;

        private event Action ParameterlessEvent;
        public Delegate      Delegate => Event;

        public void AddListener(Action<T1, T2, T3> listener)
        {
            Event -= listener;
            Event += listener;
        }

        public void RemoveListener(Action<T1, T2, T3> listener)
        {
            Event -= listener;
        }

        public void Invoke(T1 param1,
                           T2 param2,
                           T3 param3)
        {
            Event?.Invoke(param1, param2, param3);
            ParameterlessEvent?.Invoke();
        }

        public void RemoveAllListeners()
        {
            Event              = null;
            ParameterlessEvent = null;
        }

        public void RemoveListener(Action listener)
        {
            ParameterlessEvent -= listener;
        }

        public void AddListener(Action listener)
        {
            ParameterlessEvent -= listener;
            ParameterlessEvent += listener;
        }
    }
}