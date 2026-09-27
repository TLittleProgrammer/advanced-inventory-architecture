using GameData.Atlases;
using GameData.Inventory;
using GameData.LocalPackages.GameData;
using Inventory.Resource;

namespace GameData
{
    public sealed class GameDataContainer
    {
        public readonly IGameData<ResourceType, InventoryResourceData> ResourcesData;
        public readonly ISimpleData<InventoryData> Inventory;
        public readonly IGameData<string> Atlases;

        public GameDataContainer()
        {
            ResourcesData = new GameDataCollection<ResourceType, InventoryResourceData, InventoryResourcesFillableGameData>();
            Inventory = new SimpleData<InventoryFillableData, InventoryData>();
            Atlases = new GameDataCollection<string, AtlasesFillableData>();
        }
    }
}