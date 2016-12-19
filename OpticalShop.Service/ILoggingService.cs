using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpticalShop.Service
{
    /// <summary>
    /// Provided methods for any log messages
    /// </summary>
    public interface ILoggingService
    {
        void Trace(string message);
        void Trace(string message, params object[] args);

        void Debug(string message);
        void Debug(string message, params object[] args);

        void Info(string message);
        void Info(string message, params object[] args);

        void Warning(string message);
        void Warning(string message, params object[] args);

        void Error(Exception exception, string message = null, bool isStackTraceIncluded = true);

    }
}
