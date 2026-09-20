using System;
using LocalPackages.MVC;

namespace Inventory.Slot
{
    public sealed class InventorySlotModel : IModel
    {
        public readonly int Index;
        
        public ResourceArguments ResourceArgs;
        public event Action Update;
        
        public InventorySlotModel(int index)
        {
            Index = index;
        }

        public void SetResourceArguments(ResourceArguments resourceArgs)
        {
            ResourceArgs = resourceArgs;
            Update.Invoke();
        }
    }
}