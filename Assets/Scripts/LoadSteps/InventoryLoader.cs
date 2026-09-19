using System.Threading.Tasks;
using DefaultNamespace;
using Inventory;
using Inventory.UI;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace LoadSteps
{
    public sealed class InventoryLoader : IExecutable
    {
        private readonly InventoryContainer _container;
        
        private const string AddressableItemKey = "inventory_item";

        public InventoryLoader(InventoryContainer container)
        {
            _container = container;
        }

        public async Task Execute(IGameContext context)
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(AddressableItemKey);

            await handle.Task;
            
            var prefab = handle.Result.GetComponent<CanvasInventoryItemContainer>();
            var instances = await Object.InstantiateAsync(prefab, _container.Size);

            foreach (var instance in instances)
            {
                instance.transform.SetParent(_container.ItemsRoot, false);
            }
            
            Addressables.Release(handle);
        }
    }
}