using EntryPoint;
using Infrastructure;
using Logger;

namespace System.Runtime.CompilerServices.Logger
{
    public sealed class LoggerMechanicLoader : SyncExecutable
    {
        protected override void SyncExecute(IGameContext context)
        {
            context.Logger = new UnityLogger();
        }
    }
}