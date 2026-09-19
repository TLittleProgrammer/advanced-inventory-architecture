using System;
using System.Collections.Generic;
using LocalPackages.Inventory;

namespace Inventory
{
    public class BaseInventory : IInventory<IBaseResource>
    {
        public Action<IBaseResource> Added => _added;
        public Action<IBaseResource> Updated => _updated;
        public Action<IBaseResource> Removed => _removed;

        private Action<IBaseResource> _added;
        private Action<IBaseResource> _updated;
        private Action<IBaseResource> _removed;
        
        private readonly List<IBaseResource> _resources;

        public BaseInventory()
        {
            _resources = new();
        }
        
        public BaseInventory(int capacity) : this()
        {
            _resources.Capacity = capacity;
        }

        public void Add(IBaseResource resource)
        {
            foreach (var item in _resources)
            {
                if (item.Equals(resource))
                {
                    item.Amount += resource.Amount;
                    _updated?.Invoke(item);
                    
                    return;
                }
            }
            
            _resources.Add(resource);
            _added?.Invoke(resource);
        }

        public void Remove(IBaseResource resource)
        {
            if (_resources.Contains(resource))
            {
                _resources.Remove(resource);
                _removed?.Invoke(resource);
            }
        }
    }
}