using EntryPoint;
using Infrastructure;

namespace Inventory
{
    public sealed class InventoryMechanicLoader : SyncExecutable
    {
        private readonly InventoryContainer _container;

        public InventoryMechanicLoader(InventoryContainer container)
        {
            _container = container;
        }

        protected override void SyncExecute(IGameContext context)
        {
            var model = new InventoryModel(context.DataContainer.ResourcesData);
            
            context.Controllers.Add(new InventorySetUpControllers(context, model));
            context.Controllers.Add(new InventoryCollectionControllers(context, model, _container));
        }
    }
}