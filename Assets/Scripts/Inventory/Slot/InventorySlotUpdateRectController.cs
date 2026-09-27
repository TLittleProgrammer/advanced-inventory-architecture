using Infrastructure;
using LocalPackages.MVC;

namespace Inventory.Slot
{
    public sealed class InventorySlotUpdateRectController : IController
    {
        private readonly IGameContext _context;
        private readonly InventorySlotModel _model;
        private readonly InventorySlotContainer _container;

        public InventorySlotUpdateRectController(IGameContext context, InventorySlotModel model, InventorySlotContainer container)
        {
            _context = context;
            _model = model;
            _container = container;
        }

        public void Activate()
        {
            _model.UpdateRect.OnCall += OnUpdateRect;
        }

        public void Deactivate()
        {
            _model.UpdateRect.OnCall -= OnUpdateRect;
        }

        private void OnUpdateRect()
        {
            var corners = _container.GetCorners();
            var min = _context.Models.Camera.RectWorldToScreenPoint(corners.MinCorner);
            var max = _context.Models.Camera.RectWorldToScreenPoint(corners.MaxCorner);
            
            _model.SetRectArguments(min, max);
        }
    }
}