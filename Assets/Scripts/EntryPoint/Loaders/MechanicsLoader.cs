using System.Threading.Tasks;
using EntryPoint.Containers;
using Inventory;

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
            await new InventoryMechanicLoader(_container.LocationContainer.InventoryContainer).Execute(context);
        }
    }
}