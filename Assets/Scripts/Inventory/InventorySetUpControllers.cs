using Infrastructure;
using Inventory.Slot;
using LocalPackages.MVC;

namespace Inventory
{
    public sealed class InventorySetUpControllers : IController
    {
        private readonly IGameContext _context;
        private readonly InventoryModel _model;
        private readonly InventoryContainer _container;

        public InventorySetUpControllers(IGameContext context, InventoryModel model, InventoryContainer container)
        {
            _context = context;
            _model = model;
            _container = container;
        }

        public void Activate()
        {
            for (int i = 0; i < _container.Size; i++)
            {
                _model.Slots.Add(new InventorySlotModel(i));
            }
        }

        public void Deactivate()
        {
            _model.Slots.Clear();
        }
    }
}