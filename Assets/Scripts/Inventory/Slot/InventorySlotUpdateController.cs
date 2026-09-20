using DefaultNamespace;
using Inventory.UI;
using LocalPackages.MVC;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AI;
using UnityEngine.U2D;

namespace Inventory.Slot
{
    public sealed class InventorySlotUpdateController : IController
    {
        private readonly IGameContext _context;
        private readonly InventorySlotModel _model;
        private readonly CanvasInventoryItemContainer _container;

        public InventorySlotUpdateController(IGameContext context, InventorySlotModel model, CanvasInventoryItemContainer container)
        {
            _context = context;
            _model = model;
            _container = container;
        }

        public void Activate()
        {
            _model.Update += OnUpdated;
        }

        public void Deactivate()
        {
            _model.Update -= OnUpdated;
        }

        private async void OnUpdated()
        {
            var data = _context.Data.InventoryData[_model.ResourceArgs.ResourceType];
            var key = $"{data.SpriteData.AtlasId}[{data.SpriteData.SpriteId}]";
            var handle = Addressables.LoadAssetAsync<Sprite>(key);
            var sprite = await handle.Task;
            
            _container.UpdateView(sprite, _model.ResourceArgs.Amount);
            
            Addressables.Release(handle);
        }
    }
}