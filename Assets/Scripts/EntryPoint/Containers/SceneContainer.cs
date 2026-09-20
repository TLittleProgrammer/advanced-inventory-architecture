using UnityEngine;

namespace EntryPoint.Containers
{
    public sealed class SceneContainer : MonoBehaviour, ISceneContainer
    {
        public LocationContainer LocationContainer;
    }
}