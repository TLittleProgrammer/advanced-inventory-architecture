using LocalPackages.Common;
using UnityEngine.EventSystems;

namespace System.Runtime.CompilerServices.Wrappers
{
    public interface IDraggable
    {
        ITrigger<PointerEventData> BeginDrag { get; }
        ITrigger<PointerEventData> EndDrag { get; }
        ITrigger<PointerEventData> Dragging { get; }
    }
}