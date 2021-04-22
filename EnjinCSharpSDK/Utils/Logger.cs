using System;
using JetBrains.Annotations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Enjin.SDK.Utils
{
    /// <summary>
    /// Basic logger class for logging messages to the console.
    /// </summary>
    [PublicAPI]
    public class Logger : ILogger
    {
        private Microsoft.Extensions.Logging.ILogger _logger;

        /// <summary>
        /// Default constructor. Sets the logger's name to "Enjin-SDK".
        /// </summary>
        public Logger() : this("Enjin-SDK")
        {
        }
        
        /// <summary>
        /// Constructs the logger and assigns it the given name.
        /// </summary>
        /// <param name="name">The name for the logger.</param>
        public Logger(string name)
        {
            using var factory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole(options =>
                {
                    options.Format = ConsoleLoggerFormat.Default;
                    options.TimestampFormat = "HH:mm:ss "; // 24 hour format
                    options.DisableColors = true;
                });
            });

            _logger = factory.CreateLogger(name);
        }
        
        /// <inheritdoc/>
        public void Log(LogLevel level, string message)
        {
            _logger.Log(ConvertLogLevel(level), message);
        }

        /// <inheritdoc/>
        public void Log(LogLevel level, string message, Exception e)
        {
            _logger.Log(ConvertLogLevel(level), message, e);
        }

        /// <inheritdoc/>
        public bool IsLoggable(LogLevel level)
        {
            return _logger.IsEnabled(ConvertLogLevel(level));
        }

        private static Microsoft.Extensions.Logging.LogLevel ConvertLogLevel(LogLevel level)
        {
            return level switch
            {
                LogLevel.TRACE => Microsoft.Extensions.Logging.LogLevel.Trace,
                LogLevel.DEBUG => Microsoft.Extensions.Logging.LogLevel.Debug,
                LogLevel.INFO => Microsoft.Extensions.Logging.LogLevel.Information,
                LogLevel.WARN => Microsoft.Extensions.Logging.LogLevel.Warning,
                LogLevel.ERROR => Microsoft.Extensions.Logging.LogLevel.Error,
                LogLevel.SEVERE => Microsoft.Extensions.Logging.LogLevel.Critical,
                _ => Microsoft.Extensions.Logging.LogLevel.None
            };
        }
    }
}