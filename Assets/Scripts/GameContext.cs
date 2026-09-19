using System.Collections.Generic;
using LocalPackages.MVC;

namespace DefaultNamespace
{
    public sealed class GameContext : IGameContext
    {
        public GameDataContainer Data { get; } = new();
        public List<IController> Controllers { get; } = new();
    }
}