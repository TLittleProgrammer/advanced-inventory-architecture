using LoadSteps;
using UnityEngine;

namespace Canvas
{
    public sealed class EntryPoint : MonoBehaviour
    {
        public SceneContainer SceneContainer;
        
        private void Awake()
        {
            var loader = new StepsLoader();
            loader.Load(SceneContainer);
        }
    }
}