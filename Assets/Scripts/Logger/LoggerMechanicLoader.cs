using EntryPoint;
using Infrastructure;

namespace Logger
{
    public sealed class LoggerMechanicLoader : SyncExecutable
    {
        protected override void SyncExecute(IGameContext context)
        {
            context.Logger = new UnityLogger();
        }
    }
}