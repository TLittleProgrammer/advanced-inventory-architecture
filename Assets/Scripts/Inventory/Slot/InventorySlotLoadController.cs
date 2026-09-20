using System.Collections.Generic;
using Infrastructure;
using LocalPackages.MVC;
using MVC.Unity;

namespace Inventory.Slot
{
    public sealed class InventorySlotLoadController : CollectionLoadController<InventorySlotContainer>
    {
        protected override string AddressableKey => "inventory_item";
        
        private readonly IGameContext _context;
        private readonly InventoryModel _model;
        private readonly InventoryContainer _container;
        
        public InventorySlotLoadController(IGameContext context, InventoryModel model, InventoryContainer container) : base(container.Size)
        {
            _context = context;
            _model = model;
            _container = container;
        }

        protected override void InitializeContainer(InventorySlotContainer container)
        {
            container.transform.SetParent(_container.ItemsRoot, false);
        }

        protected override IEnumerable<IController> GetControllers(InventorySlotContainer container, int index)
        {
            var model = new InventorySlotModel(index);
            
            yield return new InventorySlotUpdateResourceArgumentsController(_context, model, _model);
            yield return new InventorySlotUpdateController(_context, model, container);
        }
    }
}