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
        public Logger()
        {
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
