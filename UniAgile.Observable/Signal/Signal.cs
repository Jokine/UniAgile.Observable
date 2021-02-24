using System;

namespace UniAgile.Observable
{
    public class Signal : ISignal
    {
        private event Action Event;

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

        public bool HasListeners => Event != null;

        public void Dispose()
        {
            Event = null;
            GC.SuppressFinalize(this);
        }
    }

    public class Signal<T1> : ISignal<T1>
    {
        private event Action<T1> Event;
        private event Action     ParameterlessEvent;
        public bool              HasListeners => Event != null;

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

        public void Dispose()
        {
            ParameterlessEvent = null;
            Event              = null;
            GC.SuppressFinalize(this);
        }
    }
}