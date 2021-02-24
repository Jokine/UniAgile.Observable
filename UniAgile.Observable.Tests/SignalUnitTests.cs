using System;
using Moq;
using Xunit;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable InconsistentNaming
namespace UniAgile.Observable.Tests.SignalTests
{
    public class Integration
    {
        [Theory]
        [ClassData(typeof(Extensions.MockListenerFactory))]
        public void Signal_can_create_listener_handles_for_delegates(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            this.feature_works_given_that(delegates.are_not_called)
                .when(signal.is_invoked)
                .given_that(signal.created_listener_handles_for(delegates));
        }
    }

    public class Unit
    {
        [Theory]
        [ClassData(typeof(Extensions.MockListenerFactory))]
        public void Signal_can_remove_all_its_listeners(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            this.feature_works_given_that(delegates.are_not_called)
                .when(signal.is_invoked)
                .given_that(
                            signal.has(delegates.added_as_listeners)
                                  .and_then(signal)
                                  .has(delegates.removed_from_listening));
        }


        [Theory]
        [ClassData(typeof(Extensions.MockListenerFactory))]
        public void Signal_can_add_delegates_as_listeners(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            this.feature_works_given_that(signal.has(delegates.added_as_listeners))
                .when(signal.is_invoked)
                .then(delegates.are_called);
        }


        [Theory]
        [ClassData(typeof(Extensions.MockListenerFactory))]
        public void Signal_can_remove_delegates_from_listening(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            this.feature_works_given_that(signal
                                          .has(delegates.added_as_listeners)
                                          .and_then(signal.removes_all_its_listeners))
                .when(signal.is_invoked)
                .then(delegates.are_not_called);
        }


        [Theory]
        [ClassData(typeof(Extensions.MockListenerFactory))]
        public void Signal_can_be_invoked(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            this.feature_works_given_that(signal.has(delegates.added_as_listeners))
                .when(signal.is_invoked)
                .then(delegates.are_called);
        }


        [Theory]
        [ClassData(typeof(Extensions.MockListenerFactory))]
        public void Signal_with_parameters_can_add_parameterless_delegates_as_listeners(Mock<Action>[] parameterlessDelegates)
        {
            var parametrizedSignal = new Signal<bool>();
            var withParameter      = true;

            this.feature_works_given_that(parametrizedSignal.has(parameterlessDelegates.added_as_listeners))
                .when(parametrizedSignal.is_invoked, withParameter)
                .then(parameterlessDelegates.are_called);
        }


        [Theory]
        [ClassData(typeof(Extensions.MockListenerFactory))]
        public void Signal_with_parameters_can_remove_parameterless_listeners(Mock<Action>[] parameterlessDelegates)
        {
            var parametrizedSignal = new Signal<bool>();
            var withParameter      = true;

            this.feature_works_given_that(parametrizedSignal
                                          .has(parameterlessDelegates.added_as_listeners)
                                          .and_then(parametrizedSignal)
                                          .has(parameterlessDelegates.removed_from_listening))
                .when(parametrizedSignal.is_invoked, withParameter)
                .then(parameterlessDelegates.are_not_called);
        }
    }
}