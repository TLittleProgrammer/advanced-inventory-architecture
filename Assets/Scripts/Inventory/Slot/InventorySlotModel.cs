using Inventory.Resource;
using LocalPackages.Common;
using LocalPackages.MVC;
using UnityEngine.EventSystems;

namespace Inventory.Slot
{
    public sealed class InventorySlotModel : IModel
    {
        public readonly int Index;
        public readonly Trigger<ResourceArguments> Update = new();
        public readonly Trigger<PointerEventData> DropItem = new();

        public InventorySlotModel(int index)
        {
            Index = index;
        }
    }
}