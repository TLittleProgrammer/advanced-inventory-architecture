namespace Logger
{
    public interface ILogger
    {
        void Log(string message);
        void Warning(string message);
        void Exception(string message);
    }
}