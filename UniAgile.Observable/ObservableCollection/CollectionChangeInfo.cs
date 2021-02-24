namespace UniAgile.Observable
{
    public readonly struct CollectionChangeInfo<T>
    {
        public CollectionChangeInfo(T                    target,
                                    CollectionChangeType collectionChangeType)
        {
            Target               = target;
            CollectionChangeType = collectionChangeType;
        }

        public readonly CollectionChangeType CollectionChangeType;
        public readonly T                    Target;
    }
}