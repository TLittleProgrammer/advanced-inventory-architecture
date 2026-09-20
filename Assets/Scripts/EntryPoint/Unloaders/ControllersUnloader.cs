namespace EntryPoint.Unloaders
{
    public class ControllersUnloader : SyncExecutable
    {
        protected override void SyncExecute(IGameContext context)
        {
            foreach (var controller in context.Controllers)
            {
                controller.Deactivate();
            }
        }
    }
}