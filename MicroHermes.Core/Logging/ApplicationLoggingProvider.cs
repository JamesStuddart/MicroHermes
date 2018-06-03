using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;

namespace MicroHermes.Core.Logging
{
    public class ApplicationLoggingProvider : ILoggerProvider
    {
        private readonly ConcurrentDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();

        
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, name => new ApplicationLogger());
        }
    }
}