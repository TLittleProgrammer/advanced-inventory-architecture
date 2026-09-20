using GameData.Inventory;
using GameData.LocalPackages.GameData;
using LocalPackages.Inventory;

namespace Inventory.Resource
{
    public sealed class BaseResourceSlot : ResourceSlot<BaseResource>
    {
        public ResourceType ResourceType => _resourceType;
        public int Amount => _amount;

        private readonly IGameData<ResourceType, InventoryResourceData> _data;

        private ResourceType _resourceType;
        private int _amount;

        public BaseResourceSlot(IGameData<ResourceType, InventoryResourceData> data)
        {
            _data = data;
            _resourceType = ResourceType.Unknown;
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