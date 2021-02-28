using System;
using System.Collections.Specialized;

namespace UniAgile.Observable.ObservableCollection
{
    public class CollectionChangedListenerHandle<T> : IListenerHandle
    {
        public CollectionChangedListenerHandle(INotifyCollectionChanged notifyCollectionChanged,
                                               Action<T>                onChange)
        {
            NotifyCollectionChanged = notifyCollectionChanged ?? throw new NullReferenceException();
            OnChange                = onChange                ?? throw new NullReferenceException();
        }

        private readonly INotifyCollectionChanged NotifyCollectionChanged;
        private readonly Action<T>                OnChange;

        public void Dispose()
        {
            Unsubscribe();
            GC.SuppressFinalize(this);
        }

        public void Subscribe()
        {
            if (IsSubscribed) return;

            NotifyCollectionChanged.CollectionChanged += OnCollectionChanged;
            IsSubscribed                              =  true;
        }


        public void Unsubscribe()
        {
            if (!IsSubscribed) return;

            NotifyCollectionChanged.CollectionChanged -= OnCollectionChanged;

            IsSubscribed = false;
        }

        public bool IsSubscribed { get; private set; }

        private void OnCollectionChanged(object                           sender,
                                         NotifyCollectionChangedEventArgs _)
        {
            try
            {
                OnChange((T)sender);
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to cast {sender.GetType()} to {typeof(T)}. Most likely misplaced listener. Original exception: {e.Message}");
            }
        }
    }
}