using Infrastructure;
using Inventory.Resource;
using LocalPackages.MVC;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Inventory.Slot
{
    public sealed class InventorySlotUpdateController : IController
    {
        private readonly IGameContext _context;
        private readonly InventorySlotModel _model;
        private readonly InventorySlotContainer _container;

        public InventorySlotUpdateController(IGameContext context, InventorySlotModel model, InventorySlotContainer container)
        {
            _context = context;
            _model = model;
            _container = container;
        }

        public void Activate()
        {
            _model.Update.OnCall += OnUpdated;
        }

        public void Deactivate()
        {
            _model.Update.OnCall -= OnUpdated;
        }

        private void OnUpdated(ResourceArguments args)
        {
            if (args.ResourceType == ResourceType.Unknown)
            {
                _container.UpdateView(null, 0);
                return;
            }
            
            var data = _context.Data.InventoryData[args.ResourceType];
            var sprite = _context.Models.SpriteSheets.GetSprite(data.SpriteData);

            _container.UpdateView(sprite, args.Amount);
        }
    }
}