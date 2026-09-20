using System.Threading.Tasks;
using Infrastructure;

namespace EntryPoint
{
    public interface IExecutable
    {
        Task Execute(IGameContext context);
    }
}