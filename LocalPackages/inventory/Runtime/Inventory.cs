using System;
using System.Collections.Generic;
using LocalPackages.Common;

namespace LocalPackages.Inventory
{
    public sealed class Inventory<TResource, TResourceSlot> : ISlottableInventory<TResource, TResourceSlot>
        where TResource : IResource
        where TResourceSlot : ResourceSlot<TResource>
    {
        public readonly Trigger<int> Updated = new();

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
                    Updated.Call(index);
                    return true;
                }
            }

            return false;
        }

        public bool Add(int index, TResource resource)
        {
            if (_storage[index].TryAdd(resource))
            {
                Updated.Call(index);
                return true;
            }

            return false;
        }

        public bool Remove(int index)
        {
            if (_storage[index].Clear())
            {
                Updated.Call(index);
                return true;
            }
            
            return false;
        }

        public TResourceSlot GetSlot(int index) => _storage[index];

        public void TryMerge(int sourceSlot, int targetSlot)
        {
            if (_storage[targetSlot].TryMerge(_storage[sourceSlot]))
            {
                Updated.Call(targetSlot);
                Updated.Call(sourceSlot);
            }
        }
    }
}