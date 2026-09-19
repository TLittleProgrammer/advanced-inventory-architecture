namespace GameData.LocalPackages.GameData
{
    public sealed class GameDataCollection<TKey, TData> : IGameData<TKey, TData>
    {
        private readonly IGameData<TKey,TData> _data;

        public GameDataCollection(IFillableGameData<TKey, TData> data)
        {
            _data = data;
            data.FillData();
        }

        public TData this[TKey key] => _data[key];
        public bool TryGetValue(TKey key, out TData value) => _data.TryGetValue(key, out value);
    }
}