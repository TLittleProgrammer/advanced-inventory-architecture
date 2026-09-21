using System.Collections.Generic;
using GameData;
using LocalPackages.MVC;
using Logger;

namespace Infrastructure
{
    public sealed class GameContext : IGameContext
    {
        public GameDataContainer Data { get; } = new();
        public List<IController> Controllers { get; } = new();
        public ModelsContainer Models { get; } = new();
        public ILogger Logger { get; set; }
    }
}