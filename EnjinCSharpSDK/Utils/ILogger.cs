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
    /// Enum values to represent the different logging severity levels.
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
    /// Logger interface to be implemented for use by the SDK.
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