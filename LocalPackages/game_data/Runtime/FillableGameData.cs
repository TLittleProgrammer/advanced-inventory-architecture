using System.Collections;
using System.Collections.Generic;

namespace GameData.LocalPackages.GameData
{
    public abstract class FillableGameData<TKey, TData> : IFillableGameData<TKey, TData>
    {
        public TData this[TKey key] => _data[key];

        private readonly Dictionary<TKey, TData> _data = new();

        public bool TryGetValue(TKey key, out TData value) => _data.TryGetValue(key, out value);
        public abstract void Fill();
        protected void Add(TKey key, TData value) => _data.Add(key, value);
        
        public IEnumerator<TData> GetEnumerator() => _data.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public abstract class FillableGameData<TData> : IFillableGameData<TData>
    {
        public TData this[int key] => _data[key];

        private readonly List<TData> _data = new();

        public abstract void Fill();
        protected void Add(TData value) => _data.Add(value);
        
        public IEnumerator<TData> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}