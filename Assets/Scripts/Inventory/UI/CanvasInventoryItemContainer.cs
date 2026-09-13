using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Inventory.UI
{
    public sealed class CanvasInventoryItemContainer : MonoBehaviour, IInventoryItemContainer
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _amount;
    }
}