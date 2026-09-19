using System;
using System.Collections.Generic;

namespace LocalPackages.Inventory
{
    public sealed class Inventory<TItem> : IInventory<TItem> where TItem : IResource
    {
        public event Action<TItem> Added;
        public event Action<TItem> Updated;
        public event Action<TItem> Removed;

        private readonly Dictionary<int, List<TItem>> _storage;
        
        public Inventory()
        {
            _storage = new Dictionary<int, List<TItem>>();
        }

        public Inventory(int capacity) : this()
        {
            _storage.EnsureCapacity(capacity);
        }
        
        public void Add(TItem resource)
        {
            var key = resource.GetHashCode();

            if (!_storage.TryGetValue(key, out var collection))
            {
                collection = new List<TItem>();
                _storage.Add(key, collection);
            }
            
            collection.Add(resource);
            
            Added?.Invoke(resource);
            Updated?.Invoke(resource);
        }

        public void Remove(TItem resource)
        {
            var key = resource.GetHashCode();

            if (_storage.TryGetValue(key, out var collection))
            {
                collection.Remove(resource);
                
                Removed?.Invoke(resource);
                Updated?.Invoke(resource);
            }
        }
    }
}