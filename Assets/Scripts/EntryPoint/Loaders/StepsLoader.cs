using System.Collections.Generic;
using EntryPoint.Containers;
using EntryPoint.Unloaders;

namespace EntryPoint.Loaders
{
    public sealed class StepsLoader : IEntryPoint<SceneContainer>
    {
        public async void Load(IGameContext context, SceneContainer container)
        {
            var loaders = new List<IExecutable>
            {
                new MechanicsLoader(container),
                new StartControllersLoader(),
            };

            foreach (var loader in loaders)
            {
                await loader.Execute(context);
            }
        }

        public async void Unload(IGameContext context)
        {
            var unloaders = new List<IExecutable>
            {
                new ControllersUnloader()
            };

            foreach (var unloader in unloaders)
            {
                await unloader.Execute(context);
            }
        }
    }
}