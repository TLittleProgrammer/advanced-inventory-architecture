namespace GameData.LocalPackages.GameData
{
    public interface IFillableGameData<TKey, TValue> : IGameData<TKey, TValue>, IFillable
    {
    }
    
    public interface IFillableGameData<TValue> : IGameData<TValue>, IFillable
    {
    }
}