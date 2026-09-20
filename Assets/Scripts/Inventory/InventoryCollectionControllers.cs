using System.Collections.Generic;
using Infrastructure;
using Inventory.Dropdown;
using Inventory.Slot;
using LocalPackages.MVC;

namespace Inventory
{
    public sealed class InventoryCollectionControllers : ControllersCollection
    {
        private readonly IGameContext _context;
        private readonly InventoryModel _model;
        private readonly InventoryContainer _container;

        public InventoryCollectionControllers(IGameContext context, InventoryModel model, InventoryContainer container)
        {
            _context = context;
            _model = model;
            _container = container;
        }

        protected override IEnumerable<IController> GetControllers()
        {
            yield return new InventoryDropdownSetupController(_context, _model, _container.DropdownContainer);
            yield return new InventoryDropdownAddItemController(_context, _model, _container.DropdownContainer);
            yield return new InventorySlotLoadController(_context, _model, _container);
        }
    }
}