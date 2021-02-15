using System;
using Moq;
using Xunit;


// ReSharper disable InconsistentNaming
namespace UniAgile.Observable.Tests.SignalTests
{
    public class Signal_can_remove_all_its_listeners
    {
        [Theory]
        [ClassData(typeof(Extensions.MockListenerFactory))]
        public void when_signal_is_invoked_then_delegates_are_not_called(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            delegates.can_be_added_as_listeners_to_a(signal)
                     .And(signal)
                     .can_remove_all_its_listeners()
                     .When(signal.is_invoked)
                     .Then(delegates.are_not_called);
        }
    }


    public class Delegates_can_be_added_as_listeners_to_a_signal
    {
        [Theory]
        [ClassData(typeof(Extensions.MockListenerFactory))]
        public void when_signal_is_invoked_then_delegates_are_called(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            delegates.can_be_added_as_listeners_to_a(signal)
                     .When(signal.is_invoked)
                     .Then(delegates.are_called);
        }
    }


    public class Delegates_can_be_removed_as_listeners_from_a_signal
    {
        [Theory]
        [ClassData(typeof(Extensions.MockListenerFactory))]
        public void when_signal_is_invoked_then_delegates_are_not_called(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            delegates.can_be_added_as_listeners_to_a(signal)
                     .And(delegates)
                     .can_be_removed_from_listening_to_a(signal)
                     .When(signal.is_invoked)
                     .Then(delegates.are_not_called);
        }
    }


    public class Signal_can_be_invoked
    {
        [Theory]
        [ClassData(typeof(Extensions.MockListenerFactory))]
        public static void when_signal_is_invoked_then_all_listeners_are_called(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            delegates.can_be_added_as_listeners_to_a(signal)
                     .When(signal.is_invoked)
                     .Then(delegates.are_called);
        }
    }


    public class Parameterless_delegates_can_be_added_as_listeners_to_a_parametrized_signal
    {
        [Theory]
        [ClassData(typeof(Extensions.MockListenerFactory))]
        public void when_signal_is_invoked_then_delegates_are_called(Mock<Action>[] parameterlessDelegates)
        {
            var parametrizedSignal = new Signal<bool>();
            var withParameter      = true;

            parameterlessDelegates.can_be_added_as_listeners_to_a(parametrizedSignal)
                                  .When(parametrizedSignal.is_invoked, withParameter)
                                  .Then(parameterlessDelegates.are_called);
        }
    }


    public class Parameterless_delegates_can_be_removed_as_listeners_from_a_parametrized_signal
    {
        [Theory]
        [ClassData(typeof(Extensions.MockListenerFactory))]
        public void when_signal_is_invoked_then_delegates_are_not_called(Mock<Action>[] parameterlessDelegates)
        {
            var parametrizedSignal = new Signal<bool>();
            var withParameter      = true;

            parameterlessDelegates.can_be_added_as_listeners_to_a(parametrizedSignal)
                                  .And(parameterlessDelegates)
                                  .can_be_removed_from_listening_to_a(parametrizedSignal)
                                  .When(parametrizedSignal.is_invoked, withParameter)
                                  .Then(parameterlessDelegates.are_not_called);
        }
    }
}