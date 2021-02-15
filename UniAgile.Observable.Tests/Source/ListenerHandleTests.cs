using System;
using Moq;
using Xunit;

namespace UniAgile.Observable.Tests
{
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