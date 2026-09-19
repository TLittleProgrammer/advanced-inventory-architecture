using System.Threading.Tasks;
using DefaultNamespace;

namespace LoadSteps
{
    public sealed class StartControllersLoader : IExecutable
    {
        public Task Execute(IGameContext context)
        {
            foreach (var controller in context.Controllers)
            {
                controller.Activate();
            }

            return Task.CompletedTask;
        }
    }
}