using Inventory.Resource;
using LocalPackages.Common;
using LocalPackages.MVC;
using UnityEngine.EventSystems;

namespace Inventory.Slot
{
    public sealed class InventorySlotModel : IModel
    {
        public readonly int Index;
        public readonly Trigger Update = new();
        public readonly Trigger<PointerEventData> DropItem = new();

        public ResourceType ResourceType => _resource.ResourceType;
        public int Amount => _resource.Amount;

        private BaseResource _resource;
        
        public InventorySlotModel(int index)
        {
            Index = index;
        }

        public void Increase(BaseResource resource)
        {
            _resource.Amount += resource.Amount;
            _resource.ResourceType = resource.ResourceType;
            
            Update.Call();
        }

        public void SetAmount(int amount)
        {
            _resource.Amount = amount;

            if (amount == 0)
            {
                _resource.ResourceType = ResourceType.Unknown;
            }
        }
    }
}