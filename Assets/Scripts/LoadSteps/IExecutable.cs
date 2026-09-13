using System.Threading.Tasks;

namespace LoadSteps
{
    public interface IExecutable
    {
        Task Execute();
    }
}