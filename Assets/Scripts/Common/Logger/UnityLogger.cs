using UnityEngine;

namespace Common.Logger
{
    public class UnityLogger : ILogger
    {
        public void Log(string message)
        {
            Debug.Log(message);
        }

        public void Log(string tag, string message)
        {
            Debug.Log($"[{tag}]: {message}");
        }

        public void LogWarning(string message)
        {
            Debug.LogWarning(message);
        }

        public void LogWarning(string tag, string message)
        {
            Debug.LogWarning($"[{tag}]: {message}");
        }

        public void LogError(string message)
        {
            Debug.LogError(message);
        }

        public void LogError(string tag, string message)
        {
            Debug.LogError($"[{tag}]: {message}");
        }
    }
}