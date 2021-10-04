using System;
using GymCore.Application.Interfaces;
using NLog;

namespace GymCore.API.Services
{
    public class LoggerManager : ILoggerManager
    {
        private static readonly NLog.ILogger logger = LogManager.GetCurrentClassLogger();

        public LoggerManager()
        {
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Error(Exception exp)
        {
            logger.Error(exp);
        }
    }
}
