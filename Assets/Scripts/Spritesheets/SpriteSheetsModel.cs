using System.Collections.Generic;
using GameData;
using LocalPackages.Common;
using LocalPackages.MVC;
using UnityEngine;
using UnityEngine.U2D;
using ILogger = Logger.ILogger;

namespace Spritesheets
{
    public sealed class SpriteSheetsModel : IModel
    {
        public readonly Trigger<string> LoadAtlasRequest = new();
        public readonly Trigger<string> AtlasLoaded = new();

        private readonly Dictionary<string, SpriteAtlas> _atlases = new();
        private readonly ILogger _logger;

        public SpriteSheetsModel(ILogger logger)
        {
            _logger = logger;
        }

        public void AddAtlas(string atlasId, SpriteAtlas atlas)
        {
            if (_atlases.ContainsKey(atlasId))
            {
                return;
            }

            _atlases.Add(atlasId, atlas);
            AtlasLoaded.Call(atlasId);
        }

        public Sprite GetSprite(SpriteData data)
        {
            if (_atlases.TryGetValue(data.AtlasId, out var atlas))
            {
                return atlas.GetSprite(data.SpriteId);
            }
            
            LoadAtlasRequest.Call(data.AtlasId);
            _logger.Exception($"Atlas '{data.AtlasId}' not found. Loading was called.");
            
            return null;
        }

        public bool Contains(string atlasId) => _atlases.ContainsKey(atlasId);
    }
}