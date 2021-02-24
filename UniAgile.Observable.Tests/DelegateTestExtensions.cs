using System;
using Moq;
using UniAgile.Testing;

namespace UniAgile.Testing
{
    public static class DelegateTestExtensions
    {
        private static void called(this Mock<Action> delegateMock)
        {
            delegateMock.Verify(listener => listener.Invoke(), Times.Exactly(1), "Delegate was not called. It was expected to be called");
        }

        public static void are_called(this Mock<Action>[] delegateMock)
        {
            delegateMock.Are(called);
        }

        public static void not_called(this Mock<Action> delegateMock)
        {
            delegateMock.Verify(listener => listener.Invoke(), Times.Exactly(0), "Delegate was called. It was expected not to be called");
        }

        public static void are_not_called(this Mock<Action>[] delegateMocks)
        {
            foreach (var delegateMock in delegateMocks) delegateMock.not_called();
        }
    }
}