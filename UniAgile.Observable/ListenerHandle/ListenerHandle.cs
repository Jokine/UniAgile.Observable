using System;
using System.Collections.Generic;

namespace UniAgile.Observable
{
    public class ListenerHandle<T> : IListenerHandle
    {
        public ListenerHandle(IListenableSignal<T> listenedSignal,
                              Action<T>            onChange)
        {
            ListenedSignal = listenedSignal ?? throw new NullReferenceException();
            OnChange       = onChange       ?? throw new NullReferenceException();
        }

        private readonly IListenableSignal<T> ListenedSignal;
        private readonly Action<T>            OnChange;

        public void Dispose()
        {
            Unsubscribe();
            GC.SuppressFinalize(this);
        }

        public void Subscribe()
        {
            if (IsSubscribed) return;

            ListenedSignal.AddListener(OnChange);
            IsSubscribed = true;
        }

        public void Unsubscribe()
        {
            if (!IsSubscribed) return;

            ListenedSignal.RemoveListener(OnChange);
            IsSubscribed = false;
        }

        public bool IsSubscribed { get; private set; }
    }

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

    public class ListenerHandle : IListenerHandle
    {
        public ListenerHandle(IListenableSignal listenedSignal,
                              Action            onChange)
        {
            ListenedSignal = listenedSignal ?? throw new NullReferenceException();
            OnChange       = onChange       ?? throw new NullReferenceException();
        }

        private readonly IListenableSignal ListenedSignal;
        private readonly Action            OnChange;

        public void Dispose()
        {
            Unsubscribe();
            GC.SuppressFinalize(this);
        }

        public void Subscribe()
        {
            if (IsSubscribed) return;

            ListenedSignal.AddListener(OnChange);
            IsSubscribed = true;
        }

        public void Unsubscribe()
        {
            if (!IsSubscribed) return;

            ListenedSignal.RemoveListener(OnChange);
            IsSubscribed = false;
        }

        public bool IsSubscribed { get; private set; }
    }

    public class ClosureListenerHandle : IListenerHandle
    {
        public ClosureListenerHandle(Action add,
                                     Action remove)
        {
            Add    = add    ?? throw new NullReferenceException();
            Remove = remove ?? throw new NullReferenceException();
        }

        private readonly Action Add;
        private readonly Action Remove;

        public void Dispose()
        {
            Unsubscribe();
            GC.SuppressFinalize(this);
        }

        public void Subscribe()
        {
            if (IsSubscribed) return;

            Add();
            IsSubscribed = true;
        }

        public void Unsubscribe()
        {
            if (!IsSubscribed) return;

            Remove();
            IsSubscribed = false;
        }

        public bool IsSubscribed { get; private set; }
    }
}