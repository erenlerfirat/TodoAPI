using Castle.Core.Configuration;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Targets;
using System;
using System.IO;
using ILogger = NLog.ILogger;

namespace Core.Aspects.Log
{
    public class Logger<T> : ILog<T>
    {
        private readonly ILogger _logger;
        private readonly IConfigurationRoot Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json").Build();
        public Logger()
        {
            _logger = LogManager.GetCurrentClassLogger();
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

            target.Layout = "[${level:uppercase=true}] " + fullDate + "  " + currentClass + " : ${message} ${exception:format=tostring}";

            var rule = new LoggingRule("*", LogLevel.Trace, target);

            configuration.LoggingRules.Add(rule);

            configuration.AddTarget("BaseFile", target);

            LogManager.ReconfigExistingLoggers();

            LogManager.Configuration = configuration;
        }

        public void Error(string message)
        {
            FormatLogConfig();
            _logger.Error(message);
        }

        public void Fatal(string message)
        {
            FormatLogConfig();
            _logger.Fatal(message);
        }

        public void Info(string message)
        {
            FormatLogConfig();
            _logger.Info(message);
        }

        public void Warn(string message)
        {   FormatLogConfig();
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
