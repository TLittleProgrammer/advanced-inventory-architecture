using System;
using System.Collections.Generic;

namespace LocalPackages.Inventory
{
    public sealed class Inventory<TResource, TResourceSlot> : IInventory<TResource>
        where TResource : IResource
        where TResourceSlot : ResourceSlot<TResource>
    {
        public event Action<int> Updated;

        private readonly List<TResourceSlot> _storage;
        
        public Inventory()
        {
            _storage = new List<TResourceSlot>();
        }

        public Inventory(int capacity, Func<TResourceSlot> builder) : this()
        {
            _storage.Capacity = capacity;
            
            for (var i = 0; i < _storage.Capacity; i++)
            {
                _storage.Add(builder.Invoke());
            }
        }

        public bool Add(TResource resource)
        {
            for (var index = 0; index < _storage.Count; index++)
            {
                if (_storage[index].TryAdd(resource))
                {
                    Updated?.Invoke(index);
                    return true;
                }
            }

            return false;
        }

        public bool Add(int index, TResource resource)
        {
            if (_storage[index].TryAdd(resource))
            {
                Updated?.Invoke(index);
                return true;
            }

            return false;
        }

        public bool Remove(int index)
        {
            if (_storage[index].Clear())
            {
                Updated?.Invoke(index);
                return true;
            }
            
            return false;
        }
    }
}