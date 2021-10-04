using System;

namespace GymCore.Application.Interfaces
{
    public interface ILoggerManager
    {
        void Info(string message);
        void Warn(string message);
        void Debug(string message);
        void Error(string message);
        void Error(Exception exp);
    }
}
