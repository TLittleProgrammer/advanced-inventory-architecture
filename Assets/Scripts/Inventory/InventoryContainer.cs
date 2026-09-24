using Inventory.Dropdown;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public sealed class InventoryContainer : MonoBehaviour
    {
        public int Size;
        public Transform ItemsRoot;
        public InventoryDropdownContainer DropdownContainer;
        public Transform DraggingSlotRoot;
        public GraphicRaycaster Raycaster;
    }
}