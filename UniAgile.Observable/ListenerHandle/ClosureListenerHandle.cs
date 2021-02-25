using System;

namespace UniAgile.Observable
{
    public class ClosureListenerHandle : IListenerHandle
    {
        public ClosureListenerHandle(Action add,
                                     Action remove)
        {
            Add    = add    ?? throw new NullReferenceException();
            Remove = remove ?? throw new NullReferenceException();
        }

        private readonly Action Add;
        private readonly Action Remove;

        public void Dispose()
        {
            Unsubscribe();
            GC.SuppressFinalize(this);
        }

        public void Subscribe()
        {
            if (IsSubscribed) return;

            Add();
            IsSubscribed = true;
        }

        public void Unsubscribe()
        {
            if (!IsSubscribed) return;

            Remove();
            IsSubscribed = false;
        }

        public bool IsSubscribed { get; private set; }
    }
}