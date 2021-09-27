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

namespace Enjin.SDK.Utils
{
    /// <summary>
    /// Provider class for an instance of <see cref="ILogger"/>.
    /// </summary>
    [PublicAPI]
    public class LoggerProvider
    {
        /// <summary>
        /// Represents the logger stored by this provider.
        /// </summary>
        /// <value>The logger.</value>
        public ILogger Logger { get; private set; }

        /// <summary>
        /// Represents the logging level this provider uses by default.
        /// </summary>
        /// <value>The default logging level.</value>
        public LogLevel DefaultLevel { get; private set; }

        /// <summary>
        /// Represents the logging level this provider uses for debug messages.
        /// </summary>
        /// <value>The debug logging level.</value>
        public LogLevel DebugLevel { get; private set; }

        private LoggerProvider()
        {
            throw new Exception("Private constructor used.");
        }
        
        /// <summary>
        /// Constructs a provider with the given logger and logging levels.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="defaultLevel">The default logging level.</param>
        /// <param name="debugLevel">The debug logging level.</param>
        public LoggerProvider(ILogger logger,
                              LogLevel defaultLevel = LogLevel.INFO,
                              LogLevel debugLevel = LogLevel.DEBUG)
        {
            Logger = logger ?? throw new ArgumentNullException(nameof(logger));
            DefaultLevel = defaultLevel;
            DebugLevel = debugLevel;
        }

        /// <summary>
        /// Logs the message at the default logging level.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Log(string message)
        {
            Log(DefaultLevel, message);
        }

        /// <summary>
        /// Logs the message at the debug logging level.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Debug(string message)
        {
            Log(DebugLevel, message);
        }
        
        /// <summary>
        /// Logs the message at the given logging level.
        /// </summary>
        /// <param name="level">The logging level.</param>
        /// <param name="message">The message.</param>
        public void Log(LogLevel level, string message)
        {
            if (Logger.IsLoggable(level))
            {
                Logger.Log(level, message);
            }
        }

        /// <summary>
        /// Logs the message and exception at the default logging level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="e">The exception.</param>
        public void Log(string message, Exception e)
        {
            Log(DefaultLevel, message, e);
        }

        /// <summary>
        /// Logs the message and exception at the debug logging level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="e">The exception.</param>
        public void Debug(string message, Exception e)
        {
            Log(DebugLevel, message, e);
        }

        /// <summary>
        /// Logs the message and exception at the given logging level.
        /// </summary>
        /// <param name="level">The logging level.</param>
        /// <param name="message">The message.</param>
        /// <param name="e">The exception.</param>
        public void Log(LogLevel level, string message, Exception e)
        {
            if (Logger.IsLoggable(level))
            {
                Logger.Log(level, message, e);
            }
        }

        /// <summary>
        /// Creates a new instance of a provider with default settings and containing a
        /// <see cref="Enjin.SDK.Utils.Logger"/> instance.
        /// </summary>
        /// <returns>The new logger provider.</returns>
        public static LoggerProvider CreateDefaultLoggerProvider()
        {
            return new LoggerProvider(new Logger());
        }
    }
}