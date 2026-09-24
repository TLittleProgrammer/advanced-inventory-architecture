using System.Collections.Generic;
using LocalPackages.Common;

namespace LocalPackages.MVC
{
    public abstract class ReactiveDictionaryController<TKey, TValue> : IController
    {
        private readonly ReactiveDictionary<TKey, TValue> _collection;
        private readonly Dictionary<TKey, IController> _controllersDictionary = new();

        protected ReactiveDictionaryController(ReactiveDictionary<TKey, TValue> collection)
        {
            _collection = collection;
        }
        
        public void Activate()
        {
            _collection.Added.OnCall += OnAdded;
            _collection.Removed.OnCall += OnRemoved;

            foreach (var (key, value) in _collection)
            {
                OnAdded(key, value);
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

        private void OnAdded(TKey key, TValue value)
        {
            _controllersDictionary.Add(key, GetController(key, value));
            _controllersDictionary[key].Activate();
        }

        private void OnRemoved(TKey key)
        {
            _controllersDictionary[key].Deactivate();
            _controllersDictionary.Remove(key);
        }
        
        protected abstract IController GetController(TKey key, TValue value);
    }
}