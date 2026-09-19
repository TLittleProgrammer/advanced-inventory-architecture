using DefaultNamespace;
using LoadSteps;

namespace Inventory
{
    public sealed class InventoryMechanicLoader : SyncExecutable
    {
        protected override void SyncExecute(IGameContext context)
        {
            var model = new InventoryModel(context.Data.InventoryData);
            
            
        }
    }
}