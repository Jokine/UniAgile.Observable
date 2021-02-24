using System;
using System.Linq;
using Moq;
using UniAgile.Testing;

// ReSharper disable InconsistentNaming

namespace UniAgile.Observable.Tests
{
    public static class TestExtensions
    {
        public static T then_it<T>(this T param)
        {
            return param;
        }

        public static T then_the<TSelf, T>(this TSelf self,
                                           T          param)
        {
            return param;
        }

        public static T but_then<TSelf, T>(this TSelf self,
                                           T          param)
        {
            return param;
        }

        public static T and_then<TSelf, T>(this TSelf self,
                                           T          param)
        {
            return param;
        }

        public static TSelf and_then<TSelf>(this TSelf self,
                                            Action     action)
        {
            action();

            return self;
        }

        public static TSelf and_then<TSelf, T>(this TSelf self,
                                               Action<T>  action,
                                               T          param)
        {
            action(param);

            return self;
        }

        public static T and_has<TSelf, T>(this TSelf self,
                                          T          param)
        {
            return param;
        }

        public static T has<T>(this T param,
                               Action action)
        {
            action();

            return param;
        }

        public static T has<T>(this T    param,
                               Action<T> action)
        {
            action(param);

            return param;
        }

        public static T and<T>(this T param)
        {
            return param;
        }

        public static T are<T>(this T param)
        {
            return param;
        }

        public static T will<T>(this T param)
        {
            return param;
        }

        public static T when<T>(this T param,
                                Action action)
        {
            action();

            return param;
        }

        public static T when<T>(this T    param,
                                Action<T> action)
        {
            action(param);

            return param;
        }

        public static TSelf when<TSelf, T>(this TSelf self,
                                           Action<T>  action,
                                           T          param)
        {
            action(param);

            return self;
        }
        
        public static T then<T>(this T param,
                                Action action)
        {
            action();

            return param;
        }

        public static T then<T>(this T    param,
                                Action<T> action)
        {
            action(param);

            return param;
        }

        public static TSelf then<TSelf, T>(this TSelf self,
                                           Action<T>  action,
                                           T          param)
        {
            action(param);

            return self;
        }
        
        

        public static T given_that<T>(this T param,
                                      Action action)
        {
            action();

            return param;
        }
        

        public static T given_that<TSelf, T>(this TSelf self,
                                             T          param)
        {
            return param;
        }

        public static T given_that<T>(this T    param,
                                      Action<T> action)
        {
            action(param);

            return param;
        }

        public static T feature_works_given_that<TSelf, T>(this TSelf self,
                                                      T          param)
        {
            return param;
        }

        public static T feature_works_given_that<T>(this T param,
                                                 Action action)
        {
            action();

            return param;
        }

        public static T feature_works_given_that<T>(this T    param,
                                               Action<T> action)
        {
            action(param);

            return param;
        }
    }


    public static class KeyWords
    {
        public static IListenerHandle[] unsubscribe_them(this IListenerHandle[] handles)
        {
            foreach (var handle in handles) handle.Unsubscribe();

            return handles;
        }

        public static IListenerHandle[] subscribe_them(this IListenerHandle[] handles)
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

        public static IListenerHandle[] can_create_listener_handles_to_a(this Mock<Action>[] delegateMocks,
                                                                         Signal              signal)
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


        public static Signal removed_from_listening_to_a(this Mock<Action>[] delegateMocks,
                                                         Signal              signal)
        {
            foreach (var delegateMock in delegateMocks) signal.RemoveListener(delegateMock.Object);

            return signal;
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


        private static void called(this Mock<Action> delegateMock)
        {
            delegateMock.Verify(listener => listener.Invoke(), Times.Exactly(1));
        }

        public static void are_called(this Mock<Action>[] delegateMock)
        {
            delegateMock.Are(called);
        }

        public static void not_called(this Mock<Action> delegateMock)
        {
            delegateMock.Verify(listener => listener.Invoke(), Times.Exactly(0));
        }

        public static void are_not_called(this Mock<Action>[] delegateMocks)
        {
            foreach (var delegateMock in delegateMocks) delegateMock.not_called();
        }
    }
}