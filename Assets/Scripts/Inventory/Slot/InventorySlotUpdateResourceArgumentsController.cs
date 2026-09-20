using LocalPackages.MVC;
using UnityEngine.PlayerLoop;

namespace Inventory.Slot
{
    public sealed class InventorySlotUpdateResourceArgumentsController : IController
    {
        private readonly IGameContext _context;
        private readonly InventorySlotModel _model;
        private readonly InventoryModel _inventoryModel;

        public InventorySlotUpdateResourceArgumentsController(IGameContext context, InventorySlotModel model, InventoryModel inventoryModel)
        {
            _context = context;
            _model = model;
            _inventoryModel = inventoryModel;
        }

        public void Activate()
        {
            _inventoryModel.Updated.OnCall += OnUpdateCell;
        }

        public void Deactivate()
        {
            _inventoryModel.Updated.OnCall -= OnUpdateCell;
        }

        private void OnUpdateCell(int index)
        {
            if (_model.Index != index)
            {
                return;
            }

            var resourceArgs = _inventoryModel.GetResourceArguments(_model.Index);
            _model.SetResourceArguments(resourceArgs);
        }
    }
}