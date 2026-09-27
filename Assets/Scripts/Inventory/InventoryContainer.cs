using Inventory.Dropdown;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory
{
    public sealed class InventoryContainer : MonoBehaviour
    {
        public Transform ItemsRoot;
        public InventoryDropdownContainer DropdownContainer;
        public Transform DraggingSlotRoot;
    }
}