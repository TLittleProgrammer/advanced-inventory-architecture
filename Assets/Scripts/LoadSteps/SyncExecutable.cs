using System.Threading.Tasks;
using DefaultNamespace;

namespace LoadSteps
{
    public abstract class SyncExecutable : IExecutable
    {
        public Task Execute(IGameContext context)
        {
            SyncExecute(context);
            return Task.CompletedTask;
        }

        protected abstract void SyncExecute(IGameContext context);
    }
}