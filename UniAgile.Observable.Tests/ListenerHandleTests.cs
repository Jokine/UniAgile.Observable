using System;
using Moq;
using Xunit;

namespace UniAgile.Observable.Tests.ListenerHandleTests
{
    namespace Unit
    {
        public class Delegates_can_be_subscribed_to_a_signal_without_refering_to_it
        {
            [Theory]
            [ClassData(typeof(Extensions.MockListenerFactory))]
            public void when_signal_is_invoked_then_delegates_are_called(Mock<Action>[] delegates)
            {
                var signal = new Signal();

                // delegates.can_create_listener_handles_to_a(signal)
                //          .And()
                //          .subscribe_them()
                //          .And_when(signal.is_invoked)
                //          .Then(delegates.are_called);
            }
        }

        public class Delegates_can_be_unsubscribed_from_a_signal_without_refering_to_it
        {
            [Theory]
            [ClassData(typeof(Extensions.MockListenerFactory))]
            public void when_signal_is_invoked_then_delegates_are_not_called(Mock<Action>[] delegates)
            {
                var signal = new Signal();

                // delegates.can_create_listener_handles_to_a(signal)
                //          .And()
                //          .subscribe_them()
                //          .And()
                //          .unsubscribe_them()
                //          .When(signal.is_invoked)
                //          .Then(delegates.are_called);
            }
        }
    }

    public class ListenerHandleTests
    {
        [Fact]
        public void Can_be_created_and_when_listened_signal_is_invoked_then_listener_is_not_called()
        {
            var signal = new Signal();

            var listenerMock   = new Mock<Action>();
            var listenerHandle = signal.CreateListenerHandle(listenerMock.Object);

            signal.Invoke();

            listenerMock.Verify(listener => listener.Invoke(), Times.Exactly(0));
        }

        [Fact]
        public void Can_subscribe_and_when_listened_signal_is_invoked_then_listener_is_called()
        {
            var signal = new Signal();

            var listenerMock   = new Mock<Action>();
            var listenerHandle = signal.CreateListenerHandle(listenerMock.Object);
            listenerHandle.Subscribe();

            signal.Invoke();

            listenerMock.Verify(listener => listener.Invoke(), Times.Exactly(1));
        }

        [Fact]
        public void Can_unsubscribe_and_when_listened_signal_is_invoked_then_listener_is_not_called()
        {
            var signal = new Signal();

            var listenerMock   = new Mock<Action>();
            var listenerHandle = signal.CreateListenerHandle(listenerMock.Object);
            listenerHandle.Subscribe();
            listenerHandle.Unsubscribe();

            signal.Invoke();

            listenerMock.Verify(listener => listener.Invoke(), Times.Exactly(0));
        }

        [Fact]
        public void Can_subscribe_again_and_when_listened_signal_is_invoked_then_listener_is_called()
        {
            var signal = new Signal();

            var listenerMock   = new Mock<Action>();
            var listenerHandle = signal.CreateListenerHandle(listenerMock.Object);
            listenerHandle.Subscribe();
            listenerHandle.Unsubscribe();

            signal.Invoke();

            listenerMock.Verify(listener => listener.Invoke(), Times.Exactly(0));
        }
    }
}