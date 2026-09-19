namespace LocalPackages.Inventory
{
    public interface IInventory<TItem> : Common.ICollection<TItem> where TItem : IResource
    {
        void Add(TItem resource);
        void Remove(TItem resource);
    }
}