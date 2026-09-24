using System.Collections;
using System.Collections.Generic;

namespace LocalPackages.Common
{
    public sealed class ReactiveDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        public ITrigger<TKey, TValue> Added => _added;
        public ITrigger<TKey> Removed => _removed;

        private readonly Dictionary<TKey, TValue> _collection = new();
        private readonly Trigger<TKey,TValue> _added = new();
        private readonly Trigger<TKey> _removed = new();

        public void Add(TKey key, TValue value)
        {
            _collection.Add(key, value);
            _added.Call(key, value);
        }

        public void Remove(TKey key)
        {
            _collection.Remove(key);
            _removed.Call(key);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _collection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}