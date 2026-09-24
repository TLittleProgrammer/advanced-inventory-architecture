using System.Collections.Generic;
using LocalPackages.Common;

namespace LocalPackages.MVC
{
    public abstract class ReactiveCollectionController<TKey> : IController
    {
        private readonly ReactiveCollection<TKey> _collection;
        private readonly Dictionary<TKey, IController> _controllersDictionary = new();

        protected ReactiveCollectionController(ReactiveCollection<TKey> collection)
        {
            _collection = collection;
        }
        
        public void Activate()
        {
            _collection.Added.OnCall += OnAdded;
            _collection.Removed.OnCall += OnRemoved;

            foreach (var key in _collection)
            {
                OnAdded(key);
            }
        }

        public void Deactivate()
        {
            _collection.Added.OnCall -= OnAdded;
            _collection.Removed.OnCall -= OnRemoved;

            foreach (var controller in _controllersDictionary.Values)
            {
                controller.Deactivate();
            }
            
            _controllersDictionary.Clear();
        }

        private void OnAdded(TKey key)
        {
            _controllersDictionary.Add(key, GetController(key));
            _controllersDictionary[key].Activate();
        }

        private void OnRemoved(TKey key)
        {
            _controllersDictionary[key].Deactivate();
            _controllersDictionary.Remove(key);
        }
        
        protected abstract IController GetController(TKey key);
    }
}