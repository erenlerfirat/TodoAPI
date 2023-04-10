using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Targets;
using NLog.Web;
using System;
using System.IO;
using ILogger = NLog.ILogger;

namespace Core.Aspects.Log
{
    public class Logger<T> : ILog<T> ,IDisposable
    {
        private readonly IConfigurationRoot Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json").Build();
        private readonly ILogger _logger; 
        public Logger()
        {
            FormatLogConfig();
            _logger = LogManager.GetCurrentClassLogger();
        }
        public void Dispose()
        {
            LogManager.LogFactory.Dispose();
            
            GC.SuppressFinalize(this);
        }
        private void FormatLogConfig()
        {
            LogManager.Configuration = new NLogLoggingConfiguration(Configuration.GetSection("NLog"));

            var configuration = new LoggingConfiguration();
            var target = new FileTarget();

            string fullDate = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffff");
            string today = DateTime.Now.ToString("yyyy-MM-dd");
            string currentHour = DateTime.Now.ToString("yyyy-MM-ddTHH");

            string assembly = typeof(T).Assembly.GetName().Name;
            string currentClass = typeof(T).Name;

            target.FileName = "c:\\Logs\\TODO\\" + assembly + "\\" + today + "\\" + currentHour + ".log";

            target.Layout = currentClass + "  " + fullDate + "[${level:uppercase=true}] ${message} ${exception:format=tostring}";

            var rule = new LoggingRule("*", LogLevel.Trace, target);

            configuration.LoggingRules.Add(rule);

            configuration.AddTarget("BaseFile", target);

            LogManager.ReconfigExistingLoggers();

            LogManager.Configuration = configuration;
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
