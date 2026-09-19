using System.Threading.Tasks;
using DefaultNamespace;

namespace LoadSteps
{
    public interface IExecutable
    {
        Task Execute(IGameContext context);
    }

    public interface ISyncExecutable
    {
        void Execute(IGameContext context);
    }
}