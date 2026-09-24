using System;
using GameData.Inventory;
using GameData.LocalPackages.GameData;
using LocalPackages.Inventory;
using UnityEngine;

namespace Inventory.Resource
{
    public sealed class BaseResourceSlot : ResourceSlot<BaseResource>
    {
        public ResourceType ResourceType => _resourceType;
        public int Amount => _amount;
        public override BaseResource Resource => new(ResourceType, Amount);

        private readonly IGameData<ResourceType, InventoryResourceData> _data;

        private ResourceType _resourceType;
        private int _amount;

        public BaseResourceSlot(IGameData<ResourceType, InventoryResourceData> data)
        {
            _data = data;
            _resourceType = ResourceType.Unknown;
        }

        public override void Set(BaseResource resource)
        {
            _resourceType = resource.ResourceType;
            _amount = resource.Amount;
        }

        public override bool TryAdd(BaseResource resource)
        {
            var data = _data[resource.ResourceType];
            
            if ((_resourceType != ResourceType.Unknown && _resourceType != resource.ResourceType) || _amount + resource.Amount > data.MaxCount)
            {
                return false;
            }
            
            _resourceType = resource.ResourceType;
            _amount += resource.Amount;
            return true;
        }

        public override bool TryMerge(ResourceSlot<BaseResource> slot)
        {
            var resource = slot.Resource;
            if (_resourceType != resource.ResourceType && _resourceType != ResourceType.Unknown)
            {
                return false;
            }
            
            var data = _data[resource.ResourceType];
            var oldAmount = _amount;
            
            _amount = Math.Min(_amount + resource.Amount, data.MaxCount);
            _resourceType = resource.ResourceType;
            
            var diff = _amount - resource.Amount;
            
            if (diff == oldAmount)
            {
                slot.Clear();
            }
            else
            {
                slot.Set(new BaseResource(resource.ResourceType, diff));
            }

            return true;
        }

        public override bool Clear()
        {
            if (_resourceType == ResourceType.Unknown)
            {
                return false;
            }
            
            _resourceType = ResourceType.Unknown;
            _amount = 0;
            return true;
        }
    }
}