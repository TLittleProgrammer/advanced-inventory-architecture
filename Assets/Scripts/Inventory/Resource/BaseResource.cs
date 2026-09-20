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
    }
}