namespace GameData.LocalPackages.GameData
{
    public interface ISimpleData<TValue>
    {
        TValue Data { get; }
    }
}