namespace LocalPackages.Inventory
{
    public interface ISlottableInventory<TItem, TSlot> : IInventory<TItem> where TItem : IResource
    {
        TSlot GetSlot(int index);
    }
}