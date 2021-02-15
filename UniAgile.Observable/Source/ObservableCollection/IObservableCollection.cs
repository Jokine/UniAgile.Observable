using System.Collections.Generic;

namespace UniAgile.Observable
{
    public interface IObservableCollection
    {
        int Count { get; }

        void Clear();

        IEnumerable<object> Objects();
    }

    public interface IObservableCollection<TValue> : IObservableCollection, IEnumerable<TValue>
    {
        IListenableSignal<CollectionChangeInfo<TValue>> OnCollectionChanged { get; }

        void Add(TValue item);

        bool Remove(TValue item);

        void AddRange(IEnumerable<TValue> values);
    }
}