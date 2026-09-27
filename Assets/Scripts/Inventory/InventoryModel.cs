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

        public void AddResource(BaseResource resource)
        {
            foreach (var slot in Slots)
            {
                if (CanIncreaseResourceToSlot(resource, slot))
                {
                    slot.SetType(resource.ResourceType);
                    slot.Increase(resource.Amount);
                    return;
                }
            }
        }

        public void Merge(InventorySlotModel sourceSlot, InventorySlotModel targetSlot)
        {
            var data = _data[sourceSlot.ResourceType];
            var amountSum = sourceSlot.Amount + targetSlot.Amount;
            
            targetSlot.SetAmount(Math.Min(amountSum, data.MaxCount));
            sourceSlot.SetAmount(Math.Max(amountSum - data.MaxCount, 0));
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

        public void Replace(InventorySlotModel sourceSlot, InventorySlotModel targetSlot)
        {
            var resource = new BaseResource(sourceSlot.ResourceType, sourceSlot.Amount);
            
            sourceSlot.Clear();
            sourceSlot.SetType(targetSlot.ResourceType);
            sourceSlot.SetAmount(targetSlot.Amount);

            targetSlot.Clear();
            targetSlot.SetType(resource.ResourceType);
            targetSlot.SetAmount(resource.Amount);
        }

        private bool CanIncreaseResourceToSlot(BaseResource resource, InventorySlotModel slot) =>
            slot.ResourceType == ResourceType.Unknown || (resource.ResourceType == slot.ResourceType && resource.Amount + slot.Amount <= _data[resource.ResourceType].MaxCount);
    }
}