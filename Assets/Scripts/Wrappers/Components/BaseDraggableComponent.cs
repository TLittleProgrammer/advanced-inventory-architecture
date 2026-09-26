using LocalPackages.Common;
using UnityEngine;
using UnityEngine.EventSystems;

namespace System.Runtime.CompilerServices.Wrappers.Components
{
    public class BaseDraggableComponent : MonoBehaviour, IPointerDownHandler, IPointerMoveHandler, IPointerUpHandler, ICanvasRaycastFilter, IDraggable
    {
        public RectTransform RectTransform;
        public bool IsRaycastable = false;
        
        public ITrigger<PointerEventData> BeginDrag => _beginDrag;
        public ITrigger<PointerEventData> EndDrag => _endDrag;
        public ITrigger<PointerEventData> Dragging => _dragging;
        
        private readonly Trigger<PointerEventData> _beginDrag = new();
        private readonly Trigger<PointerEventData> _endDrag = new();
        private readonly Trigger<PointerEventData> _dragging = new();

        public void OnPointerDown(PointerEventData eventData) => _beginDrag.Call(eventData);
        public void OnPointerMove(PointerEventData eventData) => _dragging.Call(eventData);
        public void OnPointerUp(PointerEventData eventData) => _endDrag.Call(eventData);
        public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera) => IsRaycastable;
    }
}