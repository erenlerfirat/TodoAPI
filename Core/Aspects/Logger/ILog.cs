using System;

namespace Core.Aspects.Log
{
    public interface ILog<T> 
    {
        void Info(string message);
        void Error(string message);
        void Fatal(string message);
        void Warn(string message);
        void Dispose();
    }
}
