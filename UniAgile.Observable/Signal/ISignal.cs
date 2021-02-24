using System;

namespace UniAgile.Observable
{
    public interface IListenableSignal : IDisposable
    {
        bool HasListeners { get; }

        void RemoveListener(Action listener);

        void AddListener(Action listener);

        void RemoveAllListeners();
    }

    public interface IListenableSignal<T> : IListenableSignal
    {
        void RemoveListener(Action<T> listener);

        void AddListener(Action<T> listener);
    }


    public interface ISignal : IListenableSignal
    {
        void Invoke();
    }

    public interface ISignal<T1> : IListenableSignal<T1>
    {
        void Invoke(T1 param);
    }
}