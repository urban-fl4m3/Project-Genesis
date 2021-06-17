namespace Common.Logger
{
    public interface ILogger
    {
        void Log(string message);
        void Log(string tag, string message);
        
        void LogWarning(string message);
        void LogWarning(string tag, string message);
        
        void LogError(string message);
        void LogError(string tag, string message);
    }
}