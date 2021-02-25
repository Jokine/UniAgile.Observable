using System;
using Moq;
using UniAgile.Testing;
using Xunit;

namespace UniAgile.Observable.Tests.ListenerHandleTests
{
    public class Unit
    {
        [Fact]
        public void Listener_handle_can_subscribe_to_a_signal_without_publicly_referring_to_it()
        {
            var signal   = new Signal();
            var listener = new Mock<Action>();

            var listenerHandle = signal.CreateListenerHandle(listener.Object);

            listenerHandle.Subscribe();

            signal.Invoke();

            listener.is_called_once();
        }


        [Fact]
        public void Listener_handle_can_unsubscribe_from_a_signal_without_publicly_referring_to_it()
        {
            var signal   = new Signal();
            var listener = new Mock<Action>();

            var listenerHandle = signal.CreateListenerHandle(listener.Object);

            listenerHandle.Subscribe();
            listenerHandle.Unsubscribe();

            signal.Invoke();

            listener.is_not_called();
        }

        [Fact]
        public void Listener_handle_can_be_created_without_listening_to_the_signal()
        {
            var signal   = new Signal();
            var listener = new Mock<Action>();

            var listenerHandle = signal.CreateListenerHandle(listener.Object);

            signal.Invoke();

            listener.is_not_called();
        }
    }
}