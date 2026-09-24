using Infrastructure;
using Inventory.Slot;
using LocalPackages.MVC;

namespace Inventory
{
    public sealed class InventorySlotCollectionController : ReactiveCollectionController<InventorySlotModel>
    {
        private readonly IGameContext _context;
        private readonly InventoryModel _inventoryModel;
        private readonly InventoryContainer _container;

        public InventorySlotCollectionController(IGameContext context, InventoryModel inventoryModel, InventoryContainer container) : base(inventoryModel.Slots)
        {
            _context = context;
            _inventoryModel = inventoryModel;
            _container = container;
        }

        protected override IController GetController(InventorySlotModel model) => new InventorySlotLoadController(_context, model, _inventoryModel, _container);
    }
}