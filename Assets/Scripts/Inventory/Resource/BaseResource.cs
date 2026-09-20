namespace Inventory.Resource
{
    public struct BaseResource : IBaseResource
    {
        public ResourceType ResourceType { get; }
        public int Amount { get; set; }

        public BaseResource(ResourceType resourceType, int amount = 1)
        {
            ResourceType = resourceType;
            Amount = amount;
        }
        
        public bool Equals(ResourceType other) => ResourceType == other;
        public override bool Equals(object obj) => obj is IBaseResource other && Equals(other.ResourceType);
        public override int GetHashCode() => (int)ResourceType;
    }
}