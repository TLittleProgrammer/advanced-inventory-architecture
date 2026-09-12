using System;
using Data.Inventory;
using LocalPackages.Inventory;

namespace Inventory
{
    public interface IBaseResource : IResource, IEquatable<ResourceType>
    {
        ResourceType ResourceType { get; }
        int Amount { get; set; }
    }
}