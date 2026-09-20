using System.Linq;
using LocalPackages.MVC;

namespace Inventory.Dropdown
{
    public sealed class InventoryDropdownSetupController : IController
    {
        private readonly IGameContext _context;
        private readonly InventoryModel _model;
        private readonly InventoryDropdownContainer _container;

        public InventoryDropdownSetupController(IGameContext context, InventoryModel model, InventoryDropdownContainer container)
        {
            _context = context;
            _model = model;
            _container = container;
        }

        public void Activate()
        {
            var options = _model.GetDropdownOptions();

            _container.Dropdown.AddOptions(options.ToList());
        }

        public void Deactivate()
        {
            _container.Dropdown.ClearOptions();
        }
    }
}