using System;
using System.Linq;
using Moq;

// ReSharper disable InconsistentNaming

namespace UniAgile.Observable.Tests
{
    public static class KeyWords
    {
        public static IListenerHandle[] are_unsubscribed(this IListenerHandle[] handles)
        {
            foreach (var handle in handles) handle.Unsubscribe();

            return handles;
        }

        public static IListenerHandle[] are_subscribed(this IListenerHandle[] handles)
        {
            foreach (var handle in handles) handle.Subscribe();

            return handles;
        }


        public static IListenerHandle[] created_listener_handles_for(this Signal    signal,
                                                                     Mock<Action>[] delegateMocks)
        {
            return delegateMocks.Select(d => signal.CreateListenerHandle(d.Object))
                                .ToArray();
        }

        public static void removes_all_its_listeners(this Signal signal)
        {
            signal.RemoveAllListeners();
        }

        public static void added_as_listeners(this Mock<Action>[] delegateMocks,
                                              Signal              signal)
        {
            foreach (var delegateMock in delegateMocks) signal.AddListener(delegateMock.Object);
        }

        public static void removed_from_listening(this Mock<Action>[] delegateMocks,
                                                  Signal              signal)
        {
            foreach (var delegateMock in delegateMocks) signal.RemoveListener(delegateMock.Object);
        }

        public static void removed_from_listening<T>(this Mock<Action>[] delegateMocks,
                                                     Signal<T>           signal)
        {
            foreach (var delegateMock in delegateMocks) signal.RemoveListener(delegateMock.Object);
        }

        public static void added_as_listeners<T>(this Mock<Action>[] delegateMocks,
                                                 Signal<T>           signal)
        {
            foreach (var delegateMock in delegateMocks) signal.AddListener(delegateMock.Object);
        }

        public static void is_invoked(this Signal signal)
        {
            signal.Invoke();
        }

        public static void is_invoked<T>(this Signal<T> signal,
                                         T              param)
        {
            signal.Invoke(param);
        }
    }
}