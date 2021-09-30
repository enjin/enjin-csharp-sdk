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
    /// Client for using the player schema.
    /// </summary>
    /// <seealso cref="EnjinHosts"/>
    [PublicAPI]
    public class PlayerClient : PlayerSchema.PlayerSchema, IClient
    {
        private PlayerClient(Uri baseUri, LoggerProvider? loggerProvider, bool debug) :
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

        /// <summary>
        /// Creates a builder for this class.
        /// </summary>
        /// <returns>The builder.</returns>
        public static PlayerClientBuilder Builder()
        {
            return new PlayerClientBuilder();
        }

        /// <summary>
        /// Builder class for <see cref="PlayerClient"/>.
        /// </summary>
        [PublicAPI]
        public class PlayerClientBuilder
        {
            private bool? _debugEnabled;
            private Uri? _host;
            private LoggerProvider? _loggerProvider;

            internal PlayerClientBuilder()
            {
            }

            /// <summary>
            /// Builds the client.
            /// </summary>
            /// <returns>The client.</returns>
            /// <exception cref="ArgumentNullException">
            /// Thrown if the host URI is a null value at the time this method is called.
            /// </exception>
            public PlayerClient Build()
            {
                if (_host == null)
                {
                    throw new ArgumentNullException($"Cannot build {nameof(PlayerClient)} with null host URI",
                                                    innerException: null);
                }

                return new PlayerClient(_host, _loggerProvider, _debugEnabled ?? false);
            }

            /// <summary>
            /// Sets whether debugging will be set for the client.
            /// </summary>
            /// <param name="enabled">Whether debugging is enabled for the client.</param>
            /// <returns>This builder for chaining.</returns>
            public PlayerClientBuilder DebugEnabled(bool enabled)
            {
                _debugEnabled = enabled;
                return this;
            }

            /// <summary>
            /// Sets the host URI the client will be using.
            /// </summary>
            /// <param name="host">The host URI.</param>
            /// <returns>This builder for chaining.</returns>
            /// <seealso cref="EnjinHosts"/>
            public PlayerClientBuilder Host(Uri host)
            {
                _host = host;
                return this;
            }

            /// <summary>
            /// Sets the logger provider for the client to use.
            /// </summary>
            /// <param name="loggerProvider">The logger provider.</param>
            /// <returns>This builder for chaining.</returns>
            public PlayerClientBuilder LoggerProvider(LoggerProvider loggerProvider)
            {
                _loggerProvider = loggerProvider;
                return this;
            }
        }
    }
}