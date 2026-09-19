using Data.Inventory;
using DefaultNamespace.GameData.Inventory;
using GameData.LocalPackages.GameData;

namespace DefaultNamespace
{
    public sealed class GameDataContainer
    {
        public readonly IGameData<ResourceType, InventoryResourceData> InventoryData;

        public GameDataContainer()
        {
            InventoryData = new GameDataCollection<ResourceType, InventoryResourceData>(new InventoryFillableGameData());
        }
    }
}