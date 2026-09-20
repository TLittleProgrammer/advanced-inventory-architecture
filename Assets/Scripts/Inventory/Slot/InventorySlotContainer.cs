using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.Slot
{
    public sealed class InventorySlotContainer : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _amount;

        public void UpdateView(Sprite sprite, int amount)
        {
            _icon.sprite = sprite;
            _amount.text = amount.ToString();
        }
    }
}