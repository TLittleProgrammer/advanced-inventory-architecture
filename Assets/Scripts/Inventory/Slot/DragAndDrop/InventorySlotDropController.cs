using Infrastructure;
using LocalPackages.MVC;
using UnityEngine;

namespace Inventory.Slot
{
    public sealed class InventorySlotDropController : IController
    {
        private readonly IGameContext _context;
        private readonly InventorySlotModel _model;
        private readonly InventoryModel _inventoryModel;

        public InventorySlotDropController(IGameContext context, InventorySlotModel model, InventoryModel inventoryModel)
        {
            _context = context;
            _model = model;
            _inventoryModel = inventoryModel;
        }

        public void Activate()
        {
            _model.DropItem.OnCall += OnDropped;
        }

        public void Deactivate()
        {
            _model.DropItem.OnCall -= OnDropped;
        }

        private void OnDropped(Vector2 position)
        {
            var model = _inventoryModel.FindSlotByPosition(position);

            if (model == null || model == _model)
            {
                return;
            }

            var data = _context.DataContainer.ResourcesData[_model.ResourceType];

            if (model.ResourceType != _model.ResourceType || data.MaxCount == model.Amount || data.MaxCount == _model.Amount)
            {
                _inventoryModel.Replace(_model, model);
            }
            else
            {
                _inventoryModel.Merge(_model, model);
            }
        }
    }
}