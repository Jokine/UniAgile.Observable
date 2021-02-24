namespace UniAgile.Observable
{
    public struct CollectionChangeInfo<T>
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