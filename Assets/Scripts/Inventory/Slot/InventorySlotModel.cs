using Inventory.Resource;
using LocalPackages.Common;
using LocalPackages.MVC;
using UnityEngine;

namespace Inventory.Slot
{
    public sealed class InventorySlotModel : IModel
    {
        public readonly int Index;
        public readonly Trigger Update = new();
        public readonly Trigger UpdateRect = new();
        public readonly Trigger<Vector2> DropItem = new();

        public ResourceType ResourceType => _resource.ResourceType;
        public int Amount => _resource.Amount;

        private BaseResource _resource;
        private Vector2 _minCorner;
        private Vector2 _maxCorner;

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

        public void SetRectArguments(Vector2 minCorner, Vector2 maxCorner)
        {
            _minCorner = minCorner;
            _maxCorner = maxCorner;
        }

        public bool Contains(Vector2 position)
        {
            UpdateRect.Call();
            
            return position.x >= _minCorner.x && position.x <= _maxCorner.x &&
                   position.y >= _minCorner.y && position.y <= _maxCorner.y;
        }
    }
}