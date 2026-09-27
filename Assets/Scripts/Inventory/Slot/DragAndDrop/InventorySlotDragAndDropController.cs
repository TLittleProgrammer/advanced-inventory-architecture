using Infrastructure;
using LocalPackages.MVC;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory.Slot
{
    public sealed class InventorySlotDragAndDropController : IController
    {
        private readonly IGameContext _context;
        private readonly InventorySlotModel _model;
        private readonly InventorySlotContainer _container;
        private readonly Transform _draggingSlotRoot;

        private bool _isDragging;
        private Transform _sourceSlotRoot;

        public InventorySlotDragAndDropController(IGameContext context, InventorySlotModel model, InventorySlotContainer container, Transform draggingSlotRoot)
        {
            _context = context;
            _model = model;
            _container = container;
            _draggingSlotRoot = draggingSlotRoot;
        }

        public void Activate()
        {
            _isDragging = false;
            _sourceSlotRoot = _container.GetDraggableParent();
            
            _container.DraggableComponent.BeginDrag.OnCall += OnMouseBeginDrag;
            _container.DraggableComponent.EndDrag.OnCall += OnMouseEndDrag;
            _container.DraggableComponent.Dragging.OnCall += OnMouseDragging;
        }

        public void Deactivate()
        {
            _container.UpdateDraggableParent(_sourceSlotRoot);
            _sourceSlotRoot = null;
            
            _container.DraggableComponent.BeginDrag.OnCall -= OnMouseBeginDrag;
            _container.DraggableComponent.EndDrag.OnCall -= OnMouseEndDrag;
            _container.DraggableComponent.Dragging.OnCall -= OnMouseDragging;
        }

        private void OnMouseBeginDrag(PointerEventData data)
        {
            if (data.button != PointerEventData.InputButton.Left || _container.IsDefaultSprite)
            {
                return;
            }
            
            _isDragging = true;
            _container.UpdateDraggableParent(_draggingSlotRoot);
        }

        private void OnMouseDragging(PointerEventData data)
        {
            if (!_isDragging)
            {
                return;
            }

            _container.IncreaseDraggablePosition(data.delta);
        }

        private void OnMouseEndDrag(PointerEventData data)
        {
            if (!_isDragging)
            {
                return;
            }

            _isDragging = false;
            _container.UpdateDraggableParent(_sourceSlotRoot);
            _container.SetPosition(Vector2.zero);
            _model.DropItem.Call(data.position);
        }
    }
}