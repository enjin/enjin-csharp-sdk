using System;
using JetBrains.Annotations;

namespace Enjin.SDK.Utils
{
    /// <summary>
    /// Represent the different logging severity levels.
    /// </summary>
    [PublicAPI]
    public enum LogLevel
    {
        TRACE,
        DEBUG,
        INFO,
        WARN,
        ERROR,
        SEVERE,
    }

    /// <summary>
    /// Logger interface to be used in the SDK.
    /// </summary>
    [PublicAPI]
    public interface ILogger
    {
        /// <summary>
        /// Logs the message at the given logging level.
        /// </summary>
        /// <param name="level">The logging level.</param>
        /// <param name="message">The message.</param>
        void Log(LogLevel level, string message);

        /// <summary>
        /// Formats and logs the message and exception at the given logging level.
        /// </summary>
        /// <param name="level">The logging level.</param>
        /// <param name="message">The message.</param>
        /// <param name="e">The exception.</param>
        void Log(LogLevel level, string message, Exception e);

        /// <summary>
        /// Determines if the given logging level is enabled for this logger.
        /// </summary>
        /// <param name="level">The logging level.</param>
        /// <returns>Whether this logger is enabled for the given logging level.</returns>
        bool IsLoggable(LogLevel level);
    }
}