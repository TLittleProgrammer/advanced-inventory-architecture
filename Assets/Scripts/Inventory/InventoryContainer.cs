using Canvas;
using UnityEngine;

namespace Inventory
{
    public sealed class InventoryContainer : MonoBehaviour
    {
        public int Size;
        public Transform ItemsRoot;
        public InventoryDropdownContainer DropdownContainer;
    }
}