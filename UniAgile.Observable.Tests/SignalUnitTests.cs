using System;
using System.Linq;
using Moq;
using UniAgile.Testing;
using Xunit;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable InconsistentNaming
namespace UniAgile.Observable.Tests.SignalTests
{
    public class Integration
    {
        [Theory]
        [ClassData(typeof(GenericDataGeneration.MockArrayFactory<Action>))]
        public void Signal_can_create_listener_handles_for_delegates(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            this.feature_works_given_that(signal.created_listener_handles_for(delegates))
                .when(signal.is_invoked)
                .then(delegates.are_not_called);
        }
    }

    public class Boundaries
    {

        [Theory]
        [ClassData(typeof(GenericDataGeneration.NullArrayFactory<Action>))]
        public void Signal_adding_null_listener_throws_an_error(Action[] delegates) => delegates.Throws(d => new Signal().AddListener(d));
        [Theory]
        [ClassData(typeof(GenericDataGeneration.MockArrayFactory<Action>))]
        public void Signal_can_not_have_same_listener_twice(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            this.feature_works_given_that(signal.has(delegates.added_as_listeners)
                                                .and_then(signal)
                                                .has(delegates.added_as_listeners))
                .when(signal.is_invoked)
                .then(delegates.are_called_once);
        }
        
    }

    public class Unit
    {
        [Theory]
        [ClassData(typeof(GenericDataGeneration.MockArrayFactory<Action>))]
        public void Signal_can_remove_all_its_listeners(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            this.feature_works_given_that(signal.has(delegates.added_as_listeners)
                                                .and_then(signal)
                                                .has(delegates.removed_from_listening))
                .when(signal.is_invoked)
                .then(delegates.are_not_called);
        }


        [Theory]
        [ClassData(typeof(GenericDataGeneration.MockArrayFactory<Action>))]
        public void Signal_can_add_delegates_as_listeners(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            this.feature_works_given_that(signal.has(delegates.added_as_listeners))
                .when(signal.is_invoked)
                .then(delegates.are_called_once);
        }


        [Theory]
        [ClassData(typeof(GenericDataGeneration.MockArrayFactory<Action>))]
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
        [ClassData(typeof(GenericDataGeneration.MockArrayFactory<Action>))]
        public void Signal_can_be_invoked(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            this.feature_works_given_that(signal.has(delegates.added_as_listeners))
                .when(signal.is_invoked)
                .then(delegates.are_called_once);
        }


        [Theory]
        [ClassData(typeof(GenericDataGeneration.MockArrayFactory<Action>))]
        public void Signal_with_parameters_can_add_parameterless_delegates_as_listeners(Mock<Action>[] parameterlessDelegates)
        {
            var parametrizedSignal = new Signal<bool>();
            var withParameter      = true;

            this.feature_works_given_that(parametrizedSignal.has(parameterlessDelegates.added_as_listeners))
                .when(parametrizedSignal.is_invoked, withParameter)
                .then(parameterlessDelegates.are_called_once);
        }


        [Theory]
        [ClassData(typeof(GenericDataGeneration.MockArrayFactory<Action>))]
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