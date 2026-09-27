using GameData.LocalPackages.GameData;

namespace GameData.Inventory
{
    public sealed class InventoryFillableData : SimpleGameData<InventoryData>
    {
        public override void Fill()
        {
            Add(new InventoryData(32));
        }
    }
}