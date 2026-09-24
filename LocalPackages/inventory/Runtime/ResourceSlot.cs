namespace LocalPackages.Inventory
{
    public abstract class ResourceSlot<TResource> where TResource : IResource
    {
        public abstract TResource Resource { get; }
        public abstract void Set(TResource resource);
        public abstract bool TryAdd(TResource resource);
        public abstract bool TryMerge(ResourceSlot<TResource> slot);
        public abstract bool Clear();
    }
}