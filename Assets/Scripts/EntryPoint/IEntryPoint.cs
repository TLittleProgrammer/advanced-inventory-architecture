using EntryPoint.Containers;
using Infrastructure;

namespace EntryPoint
{
    public interface IEntryPoint<TSceneContainer> where TSceneContainer : ISceneContainer
    {
        void Load(IGameContext gameContext, TSceneContainer sceneContainer);
        void Unload(IGameContext context);
    }
}