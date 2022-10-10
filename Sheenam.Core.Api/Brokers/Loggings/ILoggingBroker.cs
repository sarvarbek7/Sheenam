// -------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE FOR THE WORLD
// -------------------------------------------------------


namespace Sheenam.Core.Api.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogTrace(string message);
        void LogDebug(string message);
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(Exception exception);
        void LogCritical(Exception exception);
    }
}
