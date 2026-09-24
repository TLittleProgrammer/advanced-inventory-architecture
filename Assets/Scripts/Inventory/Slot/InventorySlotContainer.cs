using System.Runtime.CompilerServices.Wrappers.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.Slot
{
    public sealed class InventorySlotContainer : MonoBehaviour
    {
        public BaseDraggableComponent DraggableComponent;
        
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _amount;

        public void UpdateView(Sprite sprite, int amount)
        {
            _icon.sprite = sprite;
            _icon.color = sprite == null ? Color.clear : Color.white;
            _amount.text = amount == 0 ? string.Empty : amount.ToString();
        }

        public void UpdateIconParent(Transform parent) => _icon.transform.SetParent(parent, true);
        public Transform GetIconParent() => _icon.transform.parent;
        public void IncreaseIconPosition(Vector2 delta) => _icon.rectTransform.anchoredPosition += delta;
        public void SetIconPosition(Vector2 position) => _icon.rectTransform.anchoredPosition = position;
    }
}