using System;
using Moq;
using UniAgile.Testing;

// ReSharper disable InconsistentNaming

namespace UniAgile.Observable.Tests
{
    public static class KeyWords
    {
        public static Case can_be_added_as_listeners_to_a(this Mock<Action>[] delegateMocks,
                                                          Signal              signal)
        {
            foreach (var delegateMock in delegateMocks) signal.AddListener(delegateMock.Object);

            return new Case();
        }

        public static Case can_be_added_as_listeners_to_a<T>(this Mock<Action>[] delegateMocks,
                                                             Signal<T>           signal)
        {
            foreach (var delegateMock in delegateMocks) signal.AddListener(delegateMock.Object);

            return new Case();
        }

        public static Case can_be_removed_from_listening_to_a(this Mock<Action>[] delegateMocks,
                                                              Signal              signal)
        {
            foreach (var delegateMock in delegateMocks) signal.RemoveListener(delegateMock.Object);

            return new Case();
        }

        public static Case can_be_removed_from_listening_to_a<T>(this Mock<Action>[] delegateMocks,
                                                                 Signal<T>           signal)
        {
            foreach (var delegateMock in delegateMocks) signal.RemoveListener(delegateMock.Object);

            return new Case();
        }

        public static Case can_remove_all_its_listeners(this Signal signal)
        {
            signal.RemoveAllListeners();

            return new Case();
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