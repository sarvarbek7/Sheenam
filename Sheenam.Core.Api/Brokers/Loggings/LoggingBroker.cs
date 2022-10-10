// -------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------


using Microsoft.Extensions.Logging;

namespace Sheenam.Core.Api.Brokers.Loggings
{
    public class LoggingBroker : ILoggingBroker
    {
        private readonly ILogger<LoggingBroker> logger;

        public LoggingBroker(ILogger<LoggingBroker> logger) =>
            this.logger = logger;

        void ILoggingBroker.LogTrace(string message) =>
            this.logger.LogTrace(message);

        void ILoggingBroker.LogDebug(string message) =>
            this.logger.LogDebug(message);

        void ILoggingBroker.LogInfo(string message) =>
            this.logger.LogInformation(message);

        void ILoggingBroker.LogWarning(string message) => 
            this.logger.LogWarning(message);

        void ILoggingBroker.LogError(Exception exception) =>
            this.logger.LogError(exception, exception.Message);

        void ILoggingBroker.LogCritical(Exception exception) =>
            this.logger.LogCritical(exception, exception.Message);
    }
}
