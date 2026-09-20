using LocalPackages.Inventory;

namespace Tests
{
    internal struct TestResource : IResource
    {
        public readonly int ResourceId;
        public readonly int Amount;

        public TestResource(int resourceId, int amount)
        {
            ResourceId = resourceId;
            Amount = amount;
        }
    }
}