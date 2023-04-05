using NLog;

namespace Core.Aspects.Log
{
    public class Logger : ILog
    {
        private readonly ILogger _logger =  LogManager.GetCurrentClassLogger();

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);  
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }
    }
    public enum Log_Level
    {
        Info,
        Warn,            
        Error,
        Fatal
    }
}
