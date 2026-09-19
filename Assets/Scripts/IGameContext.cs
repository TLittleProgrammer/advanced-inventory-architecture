using System.Collections.Generic;
using LocalPackages.MVC;

namespace DefaultNamespace
{
    public interface IGameContext
    {
        GameDataContainer Data { get; }
        List<IController> Controllers { get; }
    }
}