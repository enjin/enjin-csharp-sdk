/* Copyright 2021 Enjin Pte. Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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
            _logger.Log(ConvertLogLevel(level), e, message);
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