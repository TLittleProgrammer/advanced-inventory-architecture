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
        private TContainer _instance;
        
        public async void Activate()
        {
            var handle = Addressables.LoadAssetAsync<GameObject>(AddressableKey);

            await handle.Task;
            
            var prefab = handle.Result.GetComponent<TContainer>();
            _instance = Object.Instantiate(prefab);

            InitializeContainer(_instance);
            _controllers.AddRange(GetControllers(_instance));

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
            
            if (_instance == null)
            {
                return;
            }

            Object.Destroy(_instance.gameObject);
            _instance = null;
        }

        protected abstract IEnumerable<IController> GetControllers(TContainer container);
        protected abstract void InitializeContainer(TContainer container);
    }
}