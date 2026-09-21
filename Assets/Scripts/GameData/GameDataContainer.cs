using GameData.Atlases;
using GameData.Inventory;
using GameData.LocalPackages.GameData;
using Inventory.Resource;

namespace GameData
{
    public sealed class GameDataContainer
    {
        public readonly IGameData<ResourceType, InventoryResourceData> InventoryData;
        public readonly IGameData<string> Atlases;

        public GameDataContainer()
        {
            InventoryData = new GameDataCollection<ResourceType, InventoryResourceData, InventoryFillableGameData>();
            Atlases = new GameDataCollection<string, AtlasesFillableData>();
        }
    }
}