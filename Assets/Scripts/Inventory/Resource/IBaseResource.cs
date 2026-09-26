namespace Inventory.Resource
{
    public interface IBaseResource
    {
        ResourceType ResourceType { get; }
        int Amount { get; set; }
    }
}