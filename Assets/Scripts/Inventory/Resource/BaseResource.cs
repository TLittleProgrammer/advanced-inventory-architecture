using System;
using Data.Inventory;

namespace Inventory
{
    public struct BaseResource : IBaseResource
    {
        public ResourceType ResourceType { get; }
        public int Amount { get; set; }

        public BaseResource(ResourceType resourceType, int amount)
        {
            ResourceType = resourceType;
            Amount = amount;
        }
        
        public bool Equals(ResourceType other) => ResourceType == other;
        public override bool Equals(object obj) => obj is IBaseResource other && Equals(other.ResourceType);
        public override int GetHashCode() => HashCode.Combine((int)ResourceType, Amount);
    }
}