namespace GameData.LocalPackages.GameData
{
    public interface IFillableGameData<TKey, TValue> : IGameData<TKey, TValue>
    {
        void FillData();
    }
}