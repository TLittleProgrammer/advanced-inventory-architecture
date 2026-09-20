using LocalPackages.Inventory;

namespace Inventory.Resource
{
    public interface IBaseResource : IResource
    {
        ResourceType ResourceType { get; }
        int Amount { get; set; }
    }
}