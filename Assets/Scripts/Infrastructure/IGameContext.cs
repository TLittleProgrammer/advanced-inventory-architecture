using System.Collections.Generic;
using GameData;
using LocalPackages.MVC;
using Logger;

namespace Infrastructure
{
    public interface IGameContext
    {
        GameDataContainer Data { get; }
        List<IController> Controllers { get; }
        ModelsContainer Models { get; }
        ILogger Logger { get; set; }
    }
}