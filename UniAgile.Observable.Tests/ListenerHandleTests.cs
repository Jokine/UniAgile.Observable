using System;
using System.Linq;
using Moq;
using UniAgile.Testing;
using Xunit;

namespace UniAgile.Observable.Tests.ListenerHandleTests
{
    public class Unit
    {
        private static IListenerHandle[] CreateListenerHandles(Signal         signal,
                                                               Mock<Action>[] mockDelegates)
        {
            return mockDelegates.Select(d => (IListenerHandle) new ListenerHandle(signal, d.Object))
                                .ToArray();
        }

        [Theory]
        [ClassData(typeof(GenericDataGeneration.MockArrayFactory<Action>))]
        public void Listener_handle_can_subscribe_to_a_signal_without_publicly_referring_to_it(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            var listenerHandles = CreateListenerHandles(signal, delegates);


            this.feature_works_given_that(listenerHandles.are_subscribed())
                .when(signal.is_invoked)
                .then(delegates.are_called_once);
        }


        [Theory]
        [ClassData(typeof(GenericDataGeneration.MockArrayFactory<Action>))]
        public void Listener_handle_can_unsubscribe_from_a_signal_without_publicly_referring_to_it(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            var listenerHandles = CreateListenerHandles(signal, delegates);

            this.feature_works_given_that(listenerHandles.are_unsubscribed())
                .when(signal.is_invoked)
                .then(delegates.are_not_called);
        }

        [Theory]
        [ClassData(typeof(GenericDataGeneration.MockArrayFactory<Action>))]
        public void Listener_handle_can_be_created_without_listening_to_the_signal(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            var listenerHandles = CreateListenerHandles(signal, delegates);

            this.feature_works_given(listenerHandles)
                .when(signal.is_invoked)
                .then(delegates.are_not_called);
        }
    }
}