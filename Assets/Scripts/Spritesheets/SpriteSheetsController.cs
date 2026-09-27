using Infrastructure;
using LocalPackages.MVC;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.U2D;

namespace Spritesheets
{
    public sealed class SpriteSheetsController : IController
    {
        private readonly IGameContext _context;
        private readonly SpriteSheetsModel _model;
        
        private AsyncOperationHandle<SpriteAtlas> _handle;

        public SpriteSheetsController(IGameContext context, SpriteSheetsModel model)
        {
            _context = context;
            _model = model;
        }

        public void Activate()
        {
            _model.LoadAtlasRequest.OnCall += OnLoadAtlasRequest;
        }

        public void Deactivate()
        {
            _model.LoadAtlasRequest.OnCall -= OnLoadAtlasRequest;
            
            if (_handle.IsValid())
            {
                _handle.Release();
            }
        }

        private async void OnLoadAtlasRequest(string atlasId)
        {
            if (_handle.IsValid() && !_handle.IsDone)
            {
                await _handle.Task;
            }

            if (_model.Contains(atlasId))
            {
                return;
            }
            
            _handle = Addressables.LoadAssetAsync<SpriteAtlas>(atlasId);

            await _handle.Task;
            var atlas = _handle.Result;

            _model.AddAtlas(atlasId, atlas);
        }
    }
}