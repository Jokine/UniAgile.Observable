using System;

namespace UniAgile.Observable
{
    // todo: causes garbage
    public class DeferredBinding<T> : IListenerHandle
    {
        public DeferredBinding(IListenableSignal<T> changedSignal,
                               Action<T>            onChange,
                               IListenableSignal    deferredSignal)
        {
            ChangedSignal  = changedSignal;
            OnChange       = onChange;
            DeferredSignal = deferredSignal;

            Subscribe();
        }

        public DeferredBinding(IListenableSignal<T> changedSignal,
                               Action<T>            onChange,
                               IListenableSignal    deferredSignal,
                               T                    initialValue) : this(changedSignal, onChange, deferredSignal)
        {
            Value = initialValue;
            DeferredSignal.AddListener(OnDeferredSignal);
        }

        private readonly IListenableSignal<T> ChangedSignal;
        private readonly IListenableSignal    DeferredSignal;
        private readonly Action<T>            OnChange;
        private          T                    Value;

        public void Dispose()
        {
            this.SafeUnsubscribe();
            DeferredSignal.RemoveListener(OnDeferredSignal);
            GC.SuppressFinalize(this);
        }

        public void Subscribe()
        {
            ChangedSignal.AddListener(OnChangeSignal);
            IsSubscribed = true;
        }

        public void Unsubscribe()
        {
            ChangedSignal.RemoveListener(OnChangeSignal);
            IsSubscribed = false;
        }

        public bool IsSubscribed { get; private set; }

        private void OnChangeSignal(T value)
        {
            Value = value;
            DeferredSignal.AddListener(OnDeferredSignal);
        }

        private void OnDeferredSignal()
        {
            OnChange(Value);
            DeferredSignal.RemoveListener(OnDeferredSignal);
        }
    }
}