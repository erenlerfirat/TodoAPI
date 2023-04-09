using Castle.Core.Configuration;
using Core.Helpers;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Filters;
using NLog.Layouts;
using NLog.Targets;
using System;

namespace Core.Aspects.Log
{
    public class Logger<T> : ILog<T>
    {
        private readonly IConfigurationRoot Configuration = AppSettingsHelper.Configuration;
        private readonly ILogger _logger;
        public Logger()
        {
            FormatLogConfig();
            _logger = LogManager.GetLogger(typeof(T).FullName);
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

            target.FileName = "c:\\Logs\\TODO\\"+assembly+"\\"+today+"\\"+currentHour+".log";

            target.Layout = currentClass +
                "[ ${level:uppercase=true}]  ${message} ${exception:format=tostring}"
                + fullDate;

            var rule = new LoggingRule("*", LogLevel.Trace, target);

            configuration.LoggingRules.Add(rule);

            configuration.AddTarget("BaseFile", target);

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
