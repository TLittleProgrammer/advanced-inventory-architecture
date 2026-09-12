using Data.Inventory.Attributes;
using UnityEngine;

namespace Data.Inventory
{
    [CreateAssetMenu(fileName = "Resource Data", menuName = "Inventory/Resource Data")]
    public sealed class ResourceData : ScriptableObject
    {
        [SerializedSprite]
        public Sprite Icon;
        public int MaxCount;
    }
}