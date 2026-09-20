namespace LocalPackages.Inventory
{
    public interface IInventory<TItem> where TItem : IResource
    {
        bool Add(TItem resource);
        bool Add(int index, TItem resource);
        bool Remove(int index);
    }
}