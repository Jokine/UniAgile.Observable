﻿using System;

namespace UniAgile.Observable
{
    public class ListenerHandle<T1, T2, T3> : IListenerHandle
    {
        public ListenerHandle(IListenableSignal<T1, T2, T3> listenedSignal,
                              Action<T1, T2, T3>            onChange)
        {
            ListenedSignal = listenedSignal ?? throw new NullReferenceException();
            OnChange       = onChange       ?? throw new NullReferenceException();
        }

        private readonly IListenableSignal<T1, T2, T3> ListenedSignal;
        private readonly Action<T1, T2, T3>            OnChange;

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

    public class ListenerHandle<T1, T2> : IListenerHandle
    {
        public ListenerHandle(IListenableSignal<T1, T2> listenedSignal,
                              Action<T1, T2>            onChange)
        {
            ListenedSignal = listenedSignal ?? throw new NullReferenceException();
            OnChange       = onChange       ?? throw new NullReferenceException();
        }

        private readonly IListenableSignal<T1, T2> ListenedSignal;
        private readonly Action<T1, T2>            OnChange;

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