using UnityEngine;

namespace Logger
{
    public sealed class UnityLogger : ILogger
    {
        public void Log(string message) => Debug.Log(message);
        public void Warning(string message) => Debug.LogWarning(message);
        public void Exception(string message) => Debug.LogError(message);
    }
}