using System;
using Moq;
using UniAgile.Testing;
using Xunit;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable InconsistentNaming
namespace UniAgile.Observable.Tests.SignalTests
{
    public class Integration
    {
        [Fact]
        public void Signal_can_create_listener_handles_for_delegates()
        {
            var signal = new Signal();
            var deleg  = new Mock<Action>();

            var listenerHandle = signal.CreateListenerHandle(deleg.Object);

            signal.Invoke();

            deleg.is_not_called();
        }
    }

    public class Unit
    {
        [Theory]
        [ClassData(typeof(GenericDataGeneration.MockArrayFactory<Action>))]
        public void Signal_can_remove_all_its_listeners(Mock<Action>[] delegates)
        {
            var signal = new Signal();

            foreach (var deleg in delegates)
            {
                signal.AddListener(deleg.Object);
            }
            
            signal.RemoveAllListeners();
            
            delegates.are_not_called();
        }

        [Fact]
        public void Signal_can_not_have_same_listener_twice()
        {
            var signal = new Signal();
            var listener  = new Mock<Action>();
            
            signal.AddListener(listener.Object);
            signal.AddListener(listener.Object);
            
            signal.Invoke();
            
            listener.is_called_once();
        }


        [Fact]
        public void Signal_can_add_delegates_as_listeners()
        {
            var signal = new Signal();
            var deleg  = new Mock<Action>();
            
            signal.AddListener(deleg.Object);
            
            signal.Invoke();
            
            deleg.is_called_once();
        }


        [Fact]
        public void Signal_can_remove_delegates_from_listening()
        {
            var signal = new Signal();
            var deleg  = new Mock<Action>();
            
            signal.AddListener(deleg.Object);
            signal.RemoveListener(deleg.Object);
            
            signal.Invoke();
            
            deleg.is_not_called();
        }


        [Fact]
        public void Signal_can_be_invoked()
        {
            var signal = new Signal();
            var deleg  = new Mock<Action>();
            
            signal.AddListener(deleg.Object);
            
            signal.Invoke();
            
            deleg.is_called_once();
        }


        [Fact]
        public void Signal_with_parameters_can_add_parameterless_delegates_as_listeners()
        {
            var parametrizedSignal = new Signal<bool>();
            var parameter      = true;
            var deleg              = new Mock<Action>();
            
            parametrizedSignal.AddListener(deleg.Object);
            
            parametrizedSignal.Invoke(parameter);
            
            deleg.is_called_once();
            
        }


        [Fact]
        public void Signal_with_parameters_can_remove_parameterless_listeners()
        {
            var parametrizedSignal = new Signal<bool>();
            var parameter          = true;
            var deleg              = new Mock<Action>();
            
            parametrizedSignal.AddListener(deleg.Object);
            parametrizedSignal.RemoveListener(deleg.Object);
            
            parametrizedSignal.Invoke(parameter);
            
            deleg.is_not_called();
        }
    }
}