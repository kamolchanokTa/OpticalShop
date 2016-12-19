using NLog;
using System;

namespace OpticalShop.Service
{
    /// <summary>
    ///  Logging Service which using NLog framework
    /// </summary>
    public class NLogLoggingService : ILoggingService
    {
        private readonly NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public void Trace(string message)
        {
            this.logger.Trace(message);
        }

        public void Trace(string message, params object[] args)
        {
            this.logger.Trace(message, args);
        }

        public void Debug(string message)
        {
            this.logger.Debug(message);
        }

        public void Debug(string message, params object[] args)
        {
            this.logger.Debug(message, args);
        }

        public void Info(string message)
        {
            this.logger.Info(message);
        }

        public void Info(string message, params object[] args)
        {
            this.logger.Info(message, args);
        }

        public void Warning(string message)
        {
            this.logger.Warn(message);
        }

        public void Warning(string message, params object[] args)
        {
            this.logger.Warn(message, args);
        }

        public void Error(Exception exception, string message = null, bool isStackTraceIncluded = true)
        {
            //this.logger.Error(string.IsNullOrEmpty(message) ? exception.Message : message, exception);
        }

    }
}
