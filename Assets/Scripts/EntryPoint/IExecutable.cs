using System.Threading.Tasks;

namespace EntryPoint
{
    public interface IExecutable
    {
        Task Execute(IGameContext context);
    }
}