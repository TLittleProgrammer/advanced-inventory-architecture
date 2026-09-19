using Data.Inventory;
using DefaultNamespace.GameData.Inventory;
using GameData.LocalPackages.GameData;
using LocalPackages.MVC;

namespace Inventory
{
    public sealed class InventoryModel : IModel
    {
        private readonly IGameData<ResourceType, InventoryResourceData> _data;

        public InventoryModel(IGameData<ResourceType,InventoryResourceData> data)
        {
            _data = data;
        }
    }
}