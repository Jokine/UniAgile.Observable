using System;
using System.Collections.Generic;

namespace UniAgile.Observable
{
    public class ListenerHandle<T> : IListenerHandle
    {
        public ListenerHandle(IListenableSignal<T> listenedSignal,
                              Action<T>            onChange)
        {
            ListenedSignal = listenedSignal;
            OnChange       = onChange;
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
            ListenedSignal.AddListener(OnChange);
            IsSubscribed = true;
        }

        public void Unsubscribe()
        {
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
            ListenedSignal = listenedSignal;
            Key            = key;
            OnChange       = onChange;
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
            ListenedSignal.AddListener(InternalOnChanged);
            IsSubscribed = true;
        }

        public void Unsubscribe()
        {
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
            ListenedSignal = listenedSignal;
            OnChange       = onChange;
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
            ListenedSignal.AddListener(OnChange);
            IsSubscribed = true;
        }

        public void Unsubscribe()
        {
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
            Add    = add;
            Remove = remove;
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
            Add();
            IsSubscribed = true;
        }

        public void Unsubscribe()
        {
            Remove();
            IsSubscribed = false;
        }

        public bool IsSubscribed { get; private set; }
    }
}