using System;
using LocalPackages.Inventory;

namespace Inventory.Resource
{
    public interface IBaseResource : IResource, IEquatable<ResourceType>
    {
        ResourceType ResourceType { get; }
        int Amount { get; set; }
    }
}