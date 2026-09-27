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
        private readonly InventorySlotModel _model;
        private readonly InventoryModel _inventoryModel;
        private readonly InventoryContainer _inventoryContainer;
        
        public InventorySlotLoadController(IGameContext context, InventorySlotModel model, InventoryModel inventoryModel, InventoryContainer inventoryContainer)
        {
            _context = context;
            _model = model;
            _inventoryModel = inventoryModel;
            _inventoryContainer = inventoryContainer;
        }

        protected override void InitializeContainer(InventorySlotContainer container)
        {
            container.transform.SetParent(_inventoryContainer.ItemsRoot, false);
        }

        protected override IEnumerable<IController> GetControllers(InventorySlotContainer container, int index)
        {
            yield return new InventorySlotUpdateController(_context, _model, container);
            yield return new InventorySlotDragAndDropController(_context, _model, container, _inventoryContainer.DraggingSlotRoot);
            yield return new InventorySlotDropController(_context, _model, _inventoryModel);
            yield return new InventorySlotUpdateRectController(_context, _model, container);
        }
    }
}