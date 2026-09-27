namespace GameData.LocalPackages.GameData
{
    public sealed class SimpleData<TFillable, TData> : ISimpleData<TData>
        where TFillable : SimpleGameData<TData>, new()
    {
        public TData Data => _data.Data;
        
        private readonly TFillable _data;

        public SimpleData()
        {
            _data = new TFillable();
            _data.Fill();
        }
    }
}