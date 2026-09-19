using System.Threading.Tasks;
using Canvas;
using DefaultNamespace;

namespace LoadSteps
{
    public sealed class DropdownLoader : IExecutable
    {
        private readonly AddItemContainer _container;

        public DropdownLoader(AddItemContainer container)
        {
            _container = container;
        }

        public Task Execute(IGameContext context)
        {
            return Task.CompletedTask;
        }
    }
}