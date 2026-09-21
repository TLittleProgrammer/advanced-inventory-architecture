using System.Collections.Generic;
using GameData;
using LocalPackages.Common;
using LocalPackages.MVC;
using UnityEngine;
using UnityEngine.U2D;
using ILogger = Logger.ILogger;

namespace System.Runtime.CompilerServices.SpriteSheets
{
    public sealed class SpriteSheetsModel : IModel
    {
        public readonly Trigger<string> LoadAtlasRequest = new();

        private readonly Dictionary<string, SpriteAtlas> _atlases = new();
        private readonly ILogger _logger;

        public SpriteSheetsModel(ILogger logger)
        {
            _logger = logger;
        }

        public void AddAtlas(string atlasId, SpriteAtlas atlas)
        {
            _atlases.Add(atlasId, atlas);
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