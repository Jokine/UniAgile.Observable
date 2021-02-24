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
    }
}