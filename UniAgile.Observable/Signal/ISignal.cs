using System;

namespace UniAgile.Observable
{
    public interface IListenableSignal : IBaseSignal
    {
        void RemoveListener(Action listener);

        void AddListener(Action listener);

        void RemoveAllListeners();
    }

    public interface IListenableSignal<T> : IListenableSignal
    {
        void RemoveListener(Action<T> listener);

        void AddListener(Action<T> listener);
    }

    public interface IListenableSignal<T1, T2> : IListenableSignal
    {
        void RemoveListener(Action<T1, T2> listener);

        void AddListener(Action<T1, T2> listener);
    }

    public interface IListenableSignal<T1, T2, T3> : IListenableSignal
    {
        void RemoveListener(Action<T1, T2, T3> listener);

        void AddListener(Action<T1, T2, T3> listener);
    }

    public interface IBaseSignal
    {
        Delegate Delegate { get; }
    }

    public interface ISignal : IListenableSignal
    {
        void Invoke();
    }

    public interface ISignal<T1> : IListenableSignal<T1>
    {
        void Invoke(T1 param);
    }

    public interface ISignal<T1, T2> : IListenableSignal<T1, T2>
    {
        void Invoke(T1 param1,
                    T2 param2);
    }

    public interface ISignal<T1, T2, T3> : IListenableSignal<T1, T2, T3>
    {
        void Invoke(T1 param1,
                    T2 param2,
                    T3 param3);
    }
}