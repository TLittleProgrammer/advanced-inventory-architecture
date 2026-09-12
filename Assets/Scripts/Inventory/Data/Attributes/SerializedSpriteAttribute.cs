using UnityEngine;

namespace Data.Inventory.Attributes
{
    public sealed class SerializedSpriteAttribute : PropertyAttribute
    {
        public float Size;
        
        public SerializedSpriteAttribute(float size = 64f)
        {
            Size = size;
        }
    }
}