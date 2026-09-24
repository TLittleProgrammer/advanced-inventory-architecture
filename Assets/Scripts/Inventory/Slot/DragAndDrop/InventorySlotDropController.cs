using System.Collections.Generic;
using Infrastructure;
using LocalPackages.MVC;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Inventory.Slot
{
    public sealed class InventorySlotDropController : IController
    {
        private readonly IGameContext _context;
        private readonly InventorySlotModel _model;
        private readonly InventorySlotContainer _container;
        private readonly InventoryModel _inventoryModel;
        private readonly InventoryContainer _inventoryContainer;

        public InventorySlotDropController(IGameContext context, InventorySlotModel model, InventorySlotContainer container, InventoryModel inventoryModel, InventoryContainer inventoryContainer)
        {
            _context = context;
            _model = model;
            _container = container;
            _inventoryModel = inventoryModel;
            _inventoryContainer = inventoryContainer;
        }

        public void Activate()
        {
            _model.DropItem.OnCall += OnDropped;
        }

        public void Deactivate()
        {
            _model.DropItem.OnCall -= OnDropped;
        }

        private void OnDropped(PointerEventData data)
        {
            var results = new List<RaycastResult>();
            _inventoryContainer.Raycaster.Raycast(data, results);
            
            foreach (var result in results)
            {
                if (result.gameObject.TryGetComponent<InventorySlotContainer>(out var slot))
                {
                    ProcessDroppedSlot(slot);
                    return;
                }
            }
        }

        private void ProcessDroppedSlot(InventorySlotContainer slotContainer)
        {
            if (slotContainer == _container)
            {
                Debug.Log($"AAA");
                return;
            }
            
            _inventoryModel.TryMerge(_model.Index, slotContainer.transform.GetSiblingIndex());
        }
    }
}