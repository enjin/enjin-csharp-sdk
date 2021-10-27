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

using JetBrains.Annotations;

namespace Enjin.SDK.Http
{
    /// <summary>
    /// Enum for different logging levels of HTTP traffic.
    /// </summary>
    [PublicAPI]
    public enum HttpLogLevel
    {
        /// <summary>
        /// No logging.
        /// </summary>
        NONE,

        /// <summary>
        /// Logs request and response lines.
        /// </summary>
        BASIC,

        /// <summary>
        /// Logs request and response lines as well as their respective headers.
        /// </summary>
        HEADERS,

        /// <summary>
        /// Logs request and response lines as well as their respective headers and bodies if present.
        /// </summary>
        BODY,
    }
}