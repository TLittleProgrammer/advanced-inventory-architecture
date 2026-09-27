namespace GameData.LocalPackages.GameData
{
    public abstract class SimpleGameData<TData> : ISimpleData<TData>
    {
        public TData Data { get; private set; }

        public abstract void Fill();
        protected void Add(TData value) => Data = value;
    }
}