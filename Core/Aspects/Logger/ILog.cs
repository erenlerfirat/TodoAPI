﻿namespace Core.Aspects.Log
{
    public interface ILog
    {
        void Info(string message);
        void Error(string message);
        void Fatal(string message);
        void Warn(string message);
    }
}
