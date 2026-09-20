using GameData.Inventory;
using GameData.LocalPackages.GameData;
using Inventory.Resource;

namespace GameData
{
    public sealed class GameDataContainer
    {
        public readonly IGameData<ResourceType, InventoryResourceData> InventoryData;

        public GameDataContainer()
        {
            InventoryData = new GameDataCollection<ResourceType, InventoryResourceData, InventoryFillableGameData>();
        }
    }
}