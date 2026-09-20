using System.Collections;
using System.Collections.Generic;

namespace GameData.LocalPackages.GameData
{
    public sealed class GameDataCollection<TKey, TData, TFillableGameData> : IGameData<TKey, TData> where TFillableGameData : IFillableGameData<TKey, TData>, new()
    {
        private readonly IGameData<TKey,TData> _data;

        public GameDataCollection()
        {
            var data = new TFillableGameData();
            _data = data;
            data.FillData();
        }

        public TData this[TKey key] => _data[key];
        public bool TryGetValue(TKey key, out TData value) => _data.TryGetValue(key, out value);
        public IEnumerator<TData> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}