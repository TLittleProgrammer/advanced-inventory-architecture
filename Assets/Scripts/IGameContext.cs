using System.Collections.Generic;
using GameData;
using LocalPackages.MVC;

public interface IGameContext
{
    GameDataContainer Data { get; }
    List<IController> Controllers { get; }
}