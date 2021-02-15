using System;

namespace UniAgile.Observable
{
    public interface IListenerHandle : IDisposable
    {
        bool IsSubscribed { get; }

        void Subscribe();

        void Unsubscribe();
    }
}