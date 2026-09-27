using System.Runtime.CompilerServices.Wrappers.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.Slot
{
    public sealed class InventorySlotContainer : MonoBehaviour
    {
        public BaseDraggableComponent DraggableComponent;
        
        [SerializeField] private RectTransform _rect;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _amount;

        public bool IsDefaultSprite => _icon.sprite == null;
        
        public void UpdateView(Sprite sprite, int amount)
        {
            _icon.sprite = sprite;
            _icon.color = sprite == null ? Color.clear : Color.white;
            _amount.text = amount == 0 ? string.Empty : amount.ToString();
        }
        
        public (Vector3 MinCorner, Vector3 MaxCorner) GetCorners()
        {
            var corners = new Vector3[4];
            _rect.GetWorldCorners(corners);
            
            return (corners[0], corners[2]);
        }

        public void UpdateDraggableParent(Transform parent) => DraggableComponent.transform.SetParent(parent, true);
        public Transform GetDraggableParent() => DraggableComponent.transform.parent;
        public void IncreaseDraggablePosition(Vector2 delta) => DraggableComponent.RectTransform.anchoredPosition += delta;
        public void SetPosition(Vector2 position) => DraggableComponent.RectTransform.anchoredPosition = position;
    }
}