using System.Collections.Generic;
using GameData.Inventory;
using GameData.LocalPackages.GameData;
using Inventory.Resource;
using Inventory.Slot;
using LocalPackages.Common;
using LocalPackages.Inventory;
using LocalPackages.MVC;

namespace Inventory
{
    public sealed class InventoryModel : IModel
    {
        public ITrigger<int> Updated => _inventory.Updated;
        
        public readonly ReactiveCollection<InventorySlotModel> Slots = new();
        
        private readonly IGameData<ResourceType, InventoryResourceData> _data;
        private readonly Inventory<BaseResource, BaseResourceSlot> _inventory;

        public InventoryModel(IGameData<ResourceType, InventoryResourceData> data, int capacity)
        {
            _data = data;
            _inventory = new Inventory<BaseResource, BaseResourceSlot>(capacity, () => new BaseResourceSlot(_data));
        }

        public IEnumerable<string> GetDropdownOptions()
        {
            foreach (var data in _data)
            {
                yield return data.Name;
            }
        }

        public void AddItemByIndex(int resourceIndex)
        {
            var resourceType = (ResourceType)resourceIndex;
            var resource = new BaseResource(resourceType);
            
            _inventory.Add(resource);
        }

        public ResourceArguments GetResourceArguments(int index)
        {
            var slot = _inventory.GetSlot(index);

            return new ResourceArguments(slot.ResourceType, slot.Amount);
        }

        public void TryMerge(int sourceSlot, int targetSlot)
        {
            _inventory.TryMerge(sourceSlot, targetSlot);
        }
    }
}