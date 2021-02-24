using System;
using Moq;
using Xunit;

namespace UniAgile.Observable.Tests.ListenerHandleTests
{
    public class Unit
    {
        [Theory]
        [ClassData(typeof(Extensions.MockListenerFactory))]
        public void Listener_handle_can_subscribe_to_a_signal_without_publicly_referring_to_it(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            this.feature_works_given_that(signal.created_listener_handles_for(delegates)
                                                .and_then()
                                                .unsubscribed_them())
                .when(signal.is_invoked)
                .then(delegates.are_called);
        }


        [Theory]
        [ClassData(typeof(Extensions.MockListenerFactory))]
        public void Listener_handle_can_unsubscribe_from_a_signal_without_publicly_referring_to_it(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            this.feature_works_given_that(signal.created_listener_handles_for(delegates)
                                                .and_then()
                                                .unsubscribed_them())
                .when(signal.is_invoked)
                .then(delegates.are_not_called);
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