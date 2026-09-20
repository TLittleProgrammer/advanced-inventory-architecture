using System.Collections.Generic;

namespace LocalPackages.MVC
{
    public abstract class ControllersCollection : IController
    {
        private readonly List<IController> _controllers = new();
        
        public void Activate()
        {
            _controllers.AddRange(GetControllers());
            
            foreach (var controller in _controllers)
            {
                controller.Activate();
            }
        }

        public void Deactivate()
        {
            foreach (var controller in _controllers)
            {
                controller.Deactivate();
            }
            
            _controllers.Clear();
        }

        protected abstract IEnumerable<IController> GetControllers();
    }
}