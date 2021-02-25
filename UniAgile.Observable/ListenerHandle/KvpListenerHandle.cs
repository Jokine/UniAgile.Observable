using System;
using System.Collections.Generic;

namespace UniAgile.Observable
{
    public class KvpListenerHandle<T> : IListenerHandle
    {
        public KvpListenerHandle(IListenableSignal<T>            listenedSignal,
                                 string                          key,
                                 Action<KeyValuePair<string, T>> onChange)
        {
            ListenedSignal = listenedSignal ?? throw new NullReferenceException();
            Key            = key            ?? throw new NullReferenceException();
            OnChange       = onChange       ?? throw new NullReferenceException();
        }

        private readonly string                          Key;
        private readonly IListenableSignal<T>            ListenedSignal;
        private readonly Action<KeyValuePair<string, T>> OnChange;

        public void Dispose()
        {
            Unsubscribe();
            GC.SuppressFinalize(this);
        }

        public void Subscribe()
        {
            if (IsSubscribed) return;

            ListenedSignal.AddListener(InternalOnChanged);
            IsSubscribed = true;
        }

        public void Unsubscribe()
        {
            if (!IsSubscribed) return;

            ListenedSignal.RemoveListener(InternalOnChanged);
            IsSubscribed = false;
        }

        public bool IsSubscribed { get; private set; }

        private void InternalOnChanged(T val)
        {
            OnChange(new KeyValuePair<string, T>(Key, val));
        }
    }
}