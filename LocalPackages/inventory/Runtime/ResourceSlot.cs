namespace LocalPackages.Inventory
{
    public abstract class ResourceSlot<TResource> where TResource : IResource
    {
        public abstract bool TryAdd(TResource resource);
        public abstract bool Clear();
    }
}