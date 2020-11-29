using System;
using Microsoft.Extensions.Logging;

namespace testapi.tests.unit.Controllers
{
    /// <summary>
    /// Custom logger mock
    /// </summary>
    /// <remarks>I've only created this custom logger stub because was proving tricky to mock with Moq.
    /// Perhaps Microsoft Fakes would be better but its only in preview in .NET Core.
    /// </remarks>
    public class LoggerMock<T> : ILogger<T>
    {
        private readonly LogLevel _logLevel;

        public LoggerMock(LogLevel logLevel = LogLevel.Information)
        {
            _logLevel = logLevel;
        }

        public object StateReceived { get; private set; }
        public Exception ExceptionReceived { get; private set; }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _logLevel <= logLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (_logLevel <= logLevel)
            {
                StateReceived = state;
                ExceptionReceived = exception;
                Console.WriteLine(state);
            }
        }
    }
}
