using System.Threading.Tasks;
using Canvas;
using DefaultNamespace;
using Inventory;

namespace LoadSteps
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
            await new InventoryMechanicLoader().Execute(context);
        }
    }
}