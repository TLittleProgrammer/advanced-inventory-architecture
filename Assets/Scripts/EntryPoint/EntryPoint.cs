using EntryPoint.Containers;
using EntryPoint.Loaders;
using UnityEngine;

namespace EntryPoint
{
    public sealed class EntryPoint : MonoBehaviour
    {
        public SceneContainer SceneContainer;
        
        private IEntryPoint<SceneContainer> _entryPoint = new StepsLoader();
        private IGameContext _context = new GameContext();
        
        private void Awake()
        {
            _entryPoint.Load(_context, SceneContainer);
        }

        private void OnApplicationQuit()
        {
            _entryPoint.Unload(_context);
            _entryPoint = null;
            
            _context = null;
        }
    }
}