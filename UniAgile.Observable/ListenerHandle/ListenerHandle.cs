using System;

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
}