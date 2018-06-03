using System;
using Microsoft.Extensions.Logging;

namespace MicroHermes.Core.Logging
{
    public class ApplicationLogger: ILogger
    {
        public ApplicationLogger()
        {
            
        }
        
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
           if(!IsEnabled(logLevel)) return;
            
            //do some logging here
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            //get current loglevel and check if parameter say this event should be logged 
            
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        
    }
}