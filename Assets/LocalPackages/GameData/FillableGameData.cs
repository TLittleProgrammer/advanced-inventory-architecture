using System.Collections.Generic;

namespace GameData.LocalPackages.GameData
{
    public abstract class FillableGameData<TKey, TData> : IFillableGameData<TKey, TData>
    {
        public TData this[TKey key] => _data[key];

        private readonly Dictionary<TKey, TData> _data = new();

        public bool TryGetValue(TKey key, out TData value) => _data.TryGetValue(key, out value);
        protected void Add(TKey key, TData value) => _data.Add(key, value);
        public abstract void FillData();
    }
}