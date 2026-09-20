using Inventory.Resource;
using LocalPackages.Common;
using LocalPackages.MVC;

namespace Inventory.Slot
{
    public sealed class InventorySlotModel : IModel
    {
        public readonly int Index;
        public readonly Trigger<ResourceArguments> Update = new();
        
        public InventorySlotModel(int index)
        {
            Index = index;
        }
    }
}