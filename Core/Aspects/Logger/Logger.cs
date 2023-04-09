using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Extensions.Logging;
using System.IO;

namespace Core.Aspects.Log
{
    public class Logger : ILog
    {
        private static readonly IConfigurationRoot Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json").Build();

        private readonly ILogger _logger;
        public Logger()
        {
            LogManager.Configuration = new NLogLoggingConfiguration(Configuration.GetSection("NLog"));
            _logger = LogManager.GetCurrentClassLogger();
        }

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
