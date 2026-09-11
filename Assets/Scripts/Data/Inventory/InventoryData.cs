using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.Inventory
{
    [CreateAssetMenu(fileName = "Inventory Data", menuName = "Inventory/Inventory Data")]
    public sealed class InventoryData : ScriptableObject
    {
        public Vector2 Size = new();
        public List<ResourceEntry> Resources = new();
    }

    [Serializable]
    public sealed class ResourceEntry
    {
        public ResourceType ResourceType;
        public ResourceData ResourceData;
    }
}