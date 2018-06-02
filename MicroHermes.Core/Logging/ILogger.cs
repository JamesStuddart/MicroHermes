using System;

namespace MicroHermes.Core.Logging
{
    public interface ILogger
    {
        void Log(Exception exception, LoggingSeverity severity);
        void Log(string message, LoggingSeverity severity);
    }
}