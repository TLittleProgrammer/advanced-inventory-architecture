using UnityEngine;

namespace Inventory
{
    public class CameraModel
    {
        private readonly Camera _camera;

        public CameraModel(Camera camera)
        {
            _camera = camera;
        }

        public Vector2 RectWorldToScreenPoint(Vector3 point) => RectTransformUtility.WorldToScreenPoint(_camera, point);
    }
}