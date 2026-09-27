using System;
using System.Collections.Generic;
using GameData.Inventory;
using GameData.LocalPackages.GameData;
using Inventory.Resource;
using Inventory.Slot;
using LocalPackages.Common;
using LocalPackages.MVC;
using UnityEngine;

namespace Inventory
{
    public sealed class InventoryModel : IModel
    {
        public readonly ReactiveCollection<InventorySlotModel> Slots = new();
        
        private readonly IGameData<ResourceType, InventoryResourceData> _data;

        public InventoryModel(IGameData<ResourceType, InventoryResourceData> data)
        {
            _data = data;
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
            
            foreach (var slot in Slots)
            {
                if (slot.ResourceType == ResourceType.Unknown || resource.ResourceType == slot.ResourceType)
                {
                    slot.Increase(resource);
                    return;
                }
            }
        }

        public void TryMerge(int sourceSlotIndex, int targetSlotIndex)
        {
            var sourceSlot = Slots[sourceSlotIndex];
            var targetSlot = Slots[targetSlotIndex];

            if (targetSlot.ResourceType != sourceSlot.ResourceType)
            {
                return;
            }
            
            var data = _data[sourceSlot.ResourceType];
            
            targetSlot.SetAmount(Math.Min(sourceSlot.Amount + targetSlot.Amount, data.MaxCount));
            sourceSlot.SetAmount(Math.Max(sourceSlot.Amount - targetSlot.Amount, 0));

            targetSlot.Update.Call();
            sourceSlot.Update.Call();
        }

        public InventorySlotModel FindSlotByPosition(Vector2 position)
        {
            foreach (var slot in Slots)
            {
                if (slot.Contains(position))
                {
                    return slot;
                }
            }

            return null;
        }
    }
}