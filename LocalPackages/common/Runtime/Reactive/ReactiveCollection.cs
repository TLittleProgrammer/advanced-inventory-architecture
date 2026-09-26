using System.Collections;
using System.Collections.Generic;

namespace LocalPackages.Common
{
    public sealed class ReactiveCollection<TValue> : IEnumerable<TValue>
    {
        public ITrigger<TValue> Added => _added;
        public ITrigger<TValue> Removed => _removed;
        
        public TValue this[int index] => _collection[index];

        private readonly List<TValue> _collection = new();
        private readonly Trigger<TValue> _added = new();
        private readonly Trigger<TValue> _removed = new();

        public void Add(TValue key)
        {
            _collection.Add(key);
            _added.Call(key);
        }

        public void Remove(TValue key)
        {
            _collection.Remove(key);
            _removed.Call(key);
        }

        public void Clear()
        {
            foreach (var value in _collection)
            {
                _removed.Call(value);
            }
            
            _collection.Clear();
        }

        public IEnumerator<TValue> GetEnumerator() => _collection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}