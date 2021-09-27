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
using Enjin.SDK.Utils;
using JetBrains.Annotations;

namespace Enjin.SDK
{
    /// <summary>
    /// Client for using the project schema.
    /// </summary>
    /// <seealso cref="EnjinHosts"/>
    [PublicAPI]
    public class ProjectClient : ProjectSchema.ProjectSchema, IClient
    {
        /// <summary>
        /// Constructs a client with the targeted URI, debug setting, and a default logger provider.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="debug">Whether debugging is enabled.</param>
        public ProjectClient(Uri baseUri, bool debug = false) :
            this(baseUri, LoggerProvider.CreateDefaultLoggerProvider(), debug)
        {
        }

        /// <summary>
        /// Constructs a client with the given URI, logger provider, and debug setting.
        /// </summary>
        /// <param name="baseUri">The base URI.</param>
        /// <param name="loggerProvider">The logger provider.</param>
        /// <param name="debug">Whether debugging is enabled.</param>
        public ProjectClient(Uri baseUri, LoggerProvider loggerProvider, bool debug = false) :
            base(new TrustedPlatformMiddleware(baseUri, debug), loggerProvider)
        {
        }

        /// <inheritdoc/>
        public bool IsAuthenticated => Middleware.HttpHandler.IsAuthenticated;

        /// <inheritdoc/>
        public bool IsClosed { get; private set; }

        /// <inheritdoc/>
        public void Auth(string? token)
        {
            Middleware.HttpHandler.AuthToken = token;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Middleware.HttpClient.Dispose();
            IsClosed = true;
        }
    }
}