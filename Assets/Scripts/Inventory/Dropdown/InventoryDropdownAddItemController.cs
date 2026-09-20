using Canvas;
using DefaultNamespace;
using LocalPackages.MVC;

namespace Inventory
{
    public sealed class InventoryDropdownAddItemController : IController
    {
        private readonly IGameContext _context;
        private readonly InventoryModel _model;
        private readonly InventoryDropdownContainer _container;

        public InventoryDropdownAddItemController(IGameContext context, InventoryModel model, InventoryDropdownContainer container)
        {
            _context = context;
            _model = model;
            _container = container;
        }

        public void Activate()
        {
            _container.AddItemButton.onClick.AddListener(OnAddItemButtonClicked);
        }

        public void Deactivate()
        {
            _container.AddItemButton.onClick.RemoveListener(OnAddItemButtonClicked);
        }

        private void OnAddItemButtonClicked()
        {
            _model.AddItemByIndex(_container.Dropdown.value);
        }
    }
}