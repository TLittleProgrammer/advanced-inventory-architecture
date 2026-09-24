using LocalPackages.Inventory;

namespace Tests
{
    internal sealed class TestResourceSlot : ResourceSlot<TestResource>
    {
        public int ResourceId = DefaultResourceId;
        public int Amount = 0;
        
        private const int DefaultResourceId = -1;

        public override TestResource Resource => new(ResourceId, Amount);
        
        
        public override void Set(TestResource resource)
        {
            ResourceId = resource.ResourceId;
            Amount = resource.Amount;
        }

        public override bool TryAdd(TestResource resource)
        {
            if (ResourceId == DefaultResourceId)
            {
                ResourceId = resource.ResourceId;
                Amount = resource.Amount;
                return true;
            }

            if (ResourceId != resource.ResourceId)
            {
                return false;
            }
            
            Amount += resource.Amount;
            
            return true;
        }

        public override bool TryMerge(ResourceSlot<TestResource> slot)
        {
            if (slot.Resource.ResourceId != ResourceId)
            {
                return false;
            }
            
            Amount += slot.Resource.Amount;

            return true;
        }

        public override bool Clear()
        {
            ResourceId = DefaultResourceId;
            Amount = 0;
            return true;
        }
    }
}