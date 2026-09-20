using System.Collections.Generic;

namespace GameData.LocalPackages.GameData
{
    public interface IGameData<TKey, TValue> : IEnumerable<TValue>
    {
        TValue this[TKey key] { get; }
        bool TryGetValue(TKey key, out TValue value);
    }
}