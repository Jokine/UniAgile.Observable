using System;

namespace UniAgile.Observable
{
    public static class SignalExtensions
    {
        public static IListenerHandle CreateListenerHandle(this IListenableSignal signal,
                                                           Action                 callback)
        {
            return new ListenerHandle(signal, callback);
        }

        public static IListenerHandle CreateListenerHandle<T>(this IListenableSignal<T> signal,
                                                              Action<T>                 callback)
        {
            return new ListenerHandle<T>(signal, callback);
        }

        public static IListenerHandle CreateListenerHandle<T1, T2>(this IListenableSignal<T1, T2> signal,
                                                                   Action<T1, T2>                 callback)
        {
            return new ListenerHandle<T1, T2>(signal, callback);
        }

        public static IListenerHandle CreateListenerHandle<T1, T2, T3>(this IListenableSignal<T1, T2, T3> signal,
                                                                       Action<T1, T2, T3>                 callback)
        {
            return new ListenerHandle<T1, T2, T3>(signal, callback);
        }

        public static void SafeSubscribe(this IListenerHandle handle)
        {
            if (!handle.IsSubscribed) handle.Subscribe();
        }

        public static void SafeUnsubscribe(this IListenerHandle handle)
        {
            if (handle.IsSubscribed) handle.Unsubscribe();
        }
    }
}