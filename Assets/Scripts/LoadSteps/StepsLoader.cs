using System.Collections.Generic;
using Canvas;

namespace LoadSteps
{
    public class StepsLoader
    {
        public void Load(LocationContainer container)
        {
            var loaders = new List<IExecutable>()
            {
                new InventoryLoader(container.InventoryContainer)
            };

            foreach (var loader in loaders)
            {
                loader.Execute();
            }
        }
    }
}