using EntryPoint;
using Infrastructure;
using UnityEngine;

namespace Inventory
{
    public sealed class CameraMechanicLoader : SyncExecutable
    {
        private readonly Camera _camera;

        public CameraMechanicLoader(Camera camera)
        {
            _camera = camera;
        }

        protected override void SyncExecute(IGameContext context)
        {
            var model = new CameraModel(_camera);
            context.Models.Camera = model;
        }
    }
}