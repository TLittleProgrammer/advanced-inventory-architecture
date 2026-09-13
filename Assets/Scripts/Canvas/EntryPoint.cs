using LoadSteps;
using UnityEngine;

namespace Canvas
{
    public sealed class EntryPoint : MonoBehaviour
    {
        public LocationContainer LocationContainer;
        
        private void Awake()
        {
            var loader = new StepsLoader();
            loader.Load(LocationContainer);
        }
    }
}