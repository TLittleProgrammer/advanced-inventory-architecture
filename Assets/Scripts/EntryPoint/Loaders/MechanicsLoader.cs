using System.Collections.Generic;
using System.Threading.Tasks;
using EntryPoint.Containers;
using Infrastructure;
using Inventory;
using Logger;
using Spritesheets;

namespace EntryPoint.Loaders
{
    public sealed class MechanicsLoader : IExecutable
    {
        private readonly SceneContainer _container;

        public MechanicsLoader(SceneContainer container)
        {
            _container = container;
        }

        public async Task Execute(IGameContext context)
        {
            var loaders = new List<IExecutable>
            {
                new LoggerMechanicLoader(),
                new CameraMechanicLoader(_container.LocationContainer.Camera),
                new SpriteSheetsMechanicLoader(),
                new InventoryMechanicLoader(_container.LocationContainer.InventoryContainer),
            };

            foreach (var loader in loaders)
            {
                await loader.Execute(context);
            }
        }
    }
}