using System;

namespace MicroHermes.Core.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Log(Exception exception, LoggingSeverity severity)
        {
            Log(exception.Message, severity);
        }

        public void Log(string message, LoggingSeverity severity)
        {
            Console.WriteLine($"{severity} - {message}");
        }
    }
}