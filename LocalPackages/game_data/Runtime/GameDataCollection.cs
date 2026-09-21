using System.Collections;
using System.Collections.Generic;

namespace GameData.LocalPackages.GameData
{
    public sealed class GameDataCollection<TKey, TData, TFillableGameData> : IGameData<TKey, TData>
        where TFillableGameData : IFillableGameData<TKey, TData>, IFillable, new()
    {
        private readonly IGameData<TKey,TData> _data;

        public GameDataCollection()
        {
            var data = new TFillableGameData();
            _data = data;
            data.Fill();
        }

        public TData this[TKey key] => _data[key];
        public bool TryGetValue(TKey key, out TData value) => _data.TryGetValue(key, out value);
        public IEnumerator<TData> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
    
    public sealed class GameDataCollection<TData, TFillableGameData> : IGameData<TData>
        where TFillableGameData : IFillableGameData<TData>, IFillable, new()
    {
        private readonly IGameData<TData> _data;

        public GameDataCollection()
        {
            var data = new TFillableGameData();
            _data = data;
            data.Fill();
        }

        public TData this[int index] => _data[index];
        public IEnumerator<TData> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}