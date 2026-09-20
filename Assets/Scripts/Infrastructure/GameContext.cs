using System.Collections.Generic;
using GameData;
using LocalPackages.MVC;

namespace Infrastructure
{
    public sealed class GameContext : IGameContext
    {
        public GameDataContainer Data { get; } = new();
        public List<IController> Controllers { get; } = new();
    }
}