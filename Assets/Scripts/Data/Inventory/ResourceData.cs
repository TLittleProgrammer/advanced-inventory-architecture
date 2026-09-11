using UnityEngine;

namespace Data.Inventory
{
    [CreateAssetMenu(fileName = "Resource Data", menuName = "Inventory/Resource Data")]
    public sealed class ResourceData : ScriptableObject
    {
        public ResourceType ResourceType;
        public Sprite Icon;
        public int MaxCount;
    }
}