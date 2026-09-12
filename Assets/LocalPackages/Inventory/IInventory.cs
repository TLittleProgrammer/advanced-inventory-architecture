using LocalPackages.Common;

namespace LocalPackages.Inventory
{
    public interface IInventory<TItem> : ICollection<TItem> where TItem : IResource
    {
        void Add(TItem resource);
        void Remove(TItem resource);
    }
}