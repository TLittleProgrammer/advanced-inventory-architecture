using Infrastructure;
using Inventory.Slot;
using LocalPackages.MVC;

namespace Inventory
{
    public sealed class InventorySetUpControllers : IController
    {
        private readonly IGameContext _context;
        private readonly InventoryModel _model;

        public InventorySetUpControllers(IGameContext context, InventoryModel model)
        {
            _context = context;
            _model = model;
        }

        public void Activate()
        {
            var inventoryData = _context.DataContainer.Inventory.Data;
            for (int i = 0; i < inventoryData.Size; i++)
            {
                _model.Slots.Add(new InventorySlotModel());
            }
        }

        public void Deactivate()
        {
            _model.Slots.Clear();
        }
    }
}