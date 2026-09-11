using System.Collections.Generic;
using UnityEngine;

namespace Data.Inventory
{
    [CreateAssetMenu(fileName = "Inventory Data", menuName = "Inventory/Inventory Data")]
    public sealed class InventoryData : ScriptableObject
    {
        public Vector2 Size = new();

        [SerializeField]
        public Dictionary<ResourceType, ResourceData> Resources = new();
    }
}