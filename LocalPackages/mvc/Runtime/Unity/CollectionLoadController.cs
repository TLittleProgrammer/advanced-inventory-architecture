using System.Collections.Generic;
using LocalPackages.MVC;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace MVC.Unity
{
    public abstract class CollectionLoadController<TContainer> : IController where TContainer : MonoBehaviour
    {
        protected abstract string AddressableKey { get; }

        private readonly List<IController> _controllers = new();
        private readonly int _count;
        private TContainer[] _instances;

        protected CollectionLoadController(int count = 1)
        {
            _count = count;
        }
        
        public async void Activate()
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(AddressableKey);

            await handle.Task;
            
            var prefab = handle.Result.GetComponent<TContainer>();
            _instances = await Object.InstantiateAsync(prefab, _count);

            for(var index = 0; index < _count; index++)
            {
                var instance = _instances[index];
                InitializeContainer(instance);
                _controllers.AddRange(GetControllers(instance, index));
            }

            foreach (var controller in _controllers)
            {
                controller.Activate();
            }
            
            Addressables.Release(handle);
        }

        public void Deactivate()
        {
            foreach (var controller in _controllers)
            {
                controller.Deactivate();
            }
            
            _controllers.Clear();
            
            foreach (var instance in _instances)
            {
                Object.Destroy(instance);
            }
        }

        protected abstract IEnumerable<IController> GetControllers(TContainer container, int index);
        protected abstract void InitializeContainer(TContainer container);
    }
}