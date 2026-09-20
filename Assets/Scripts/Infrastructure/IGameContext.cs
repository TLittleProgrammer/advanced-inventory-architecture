using System.Collections.Generic;
using GameData;
using LocalPackages.MVC;

namespace Infrastructure
{
    public interface IGameContext
    {
        GameDataContainer Data { get; }
        List<IController> Controllers { get; }
    }
}