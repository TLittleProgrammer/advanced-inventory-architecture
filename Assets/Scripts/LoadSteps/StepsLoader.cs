using System.Collections.Generic;
using Canvas;
using DefaultNamespace;

namespace LoadSteps
{
    public class StepsLoader
    {
        public async void Load(SceneContainer container)
        {
            var context = new GameContext();
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
    }
}