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
using System.Timers;
using Enjin.SDK.Http;
using Enjin.SDK.Models;
using Enjin.SDK.ProjectSchema;
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
        private readonly Timer? _authTimer;
        private readonly string? _uuid;
        private readonly string? _secret;

        /// <summary>
        /// Amount of time in seconds to preempt the expiration period of a access token.
        /// </summary>
        private const int PreemptAuthExpirationTime = 60;

        /// <inheritdoc/>
        public bool IsAuthenticated => Middleware.HttpHandler.IsAuthenticated;

        /// <summary>
        /// Represents whether this client is enabled for automatic authentication.
        /// </summary>
        /// <value>Whether this client is enabled for automatic authentication.</value>
        public bool IsAutomaticAuthenticationEnabled { get; }

        /// <inheritdoc/>
        public bool IsClosed { get; private set; }

        /// <summary>
        /// Represents whether the authentication timer is running.
        /// </summary>
        /// <value>Whether the authentication timer is running.</value>
        public bool IsTimerRunning { get; private set; }

        /// <summary>
        /// Event handler for when the authentication timer is stopped.
        /// </summary>
        public EventHandler? OnAutomaticAuthenticationStopped;

        private ProjectClient(Uri baseUri,
                              bool automaticAuthentication,
                              string? uuid,
                              string? secret,
                              HttpLogLevel httpLogLevel,
                              LoggerProvider? loggerProvider)
            : base(new TrustedPlatformMiddleware(baseUri, httpLogLevel, loggerProvider), loggerProvider)
        {
            IsAutomaticAuthenticationEnabled = automaticAuthentication;
            if (!IsAutomaticAuthenticationEnabled)
                return;

            if (uuid == null || secret == null)
                throw new ArgumentException("Cannot enable client for automatic authentication without a UUID and secret.");

            _uuid = uuid;
            _secret = secret;
            _authTimer = new Timer
            {
                AutoReset = false,
            };
            _authTimer.Disposed += (sender, args) => IsTimerRunning = false;
            _authTimer.Elapsed += (sender, args) => SendRequestAndAuth();
            SendRequestAndAuth();
        }

        /// <inheritdoc/>
        public void Auth(string? token)
        {
            Middleware.HttpHandler.AuthToken = token;
        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentException">
        /// If <paramref name="accessToken"/> is not null and either its <see cref="AccessToken.Token"/> or
        /// <see cref="AccessToken.ExpiresIn"/> properties are null.
        /// </exception>
        /// <remarks>
        /// If this client has automatic authentication enabled, then this method may restart the timer when
        /// <paramref name="accessToken"/> has expiration data or stop the timer otherwise.
        /// </remarks>
        public void Auth(AccessToken? accessToken)
        {
            if (accessToken != null && (accessToken.Token == null || accessToken.ExpiresIn == null))
                throw new ArgumentException($"{nameof(accessToken)} has missing token or expiration data.");

            if (IsAutomaticAuthenticationEnabled)
                RestartAuthenticationTimer(accessToken);

            Middleware.HttpHandler.AuthToken = accessToken?.Token;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _authTimer?.Close();
            Middleware.HttpClient.Dispose();
            IsClosed = true;
        }

        private void RestartAuthenticationTimer(AccessToken? accessToken)
        {
            if (_authTimer == null)
                return;

            _authTimer.Stop();
            IsTimerRunning = false;

            if (accessToken is { ExpiresIn: { } })
            {
                var interval = accessToken.ExpiresIn.Value;
                if (interval - PreemptAuthExpirationTime > 0)
                    interval -= PreemptAuthExpirationTime;

                _authTimer.Interval = interval * 1000; // Convert to milliseconds
                _authTimer.Start();
                IsTimerRunning = true;
            }
            else
            {
                OnAutomaticAuthenticationStopped?.Invoke(this, EventArgs.Empty);
            }
        }

        private void SendRequestAndAuth()
        {
            if (_uuid == null || _secret == null)
                throw new InvalidOperationException("Client cannot automatically send auth request without a UUID or secret.");

            var req = new AuthProject().Uuid(_uuid).Secret(_secret);
            AuthProject(req).ContinueWith(task =>
            {
                // TODO: Perform checks on the task and the response.
                var accessToken = task.Result.Result;
                Auth(accessToken);
            });
        }

        /// <summary>
        /// Creates a builder for this class.
        /// </summary>
        /// <returns>The builder.</returns>
        public static ProjectClientBuilder Builder()
        {
            return new ProjectClientBuilder();
        }

        /// <summary>
        /// Builder class for <see cref="ProjectClient"/>.
        /// </summary>
        [PublicAPI]
        public class ProjectClientBuilder
        {
            private Uri? _baseUri;
            private bool? _automaticAuthentication;
            private string? _uuid;
            private string? _secret;
            private HttpLogLevel? _httpLogLevel;
            private LoggerProvider? _loggerProvider;

            internal ProjectClientBuilder()
            {
            }

            /// <summary>
            /// Builds the client.
            /// </summary>
            /// <returns>The client.</returns>
            /// <exception cref="InvalidOperationException">
            /// Thrown if the base URI is a null value at the time this method is called.
            /// </exception>
            public ProjectClient Build()
            {
                if (_baseUri == null)
                    throw new InvalidOperationException($"Cannot build {nameof(ProjectClient)} with null base URI.");

                return new ProjectClient(_baseUri,
                                         _automaticAuthentication ?? false,
                                         _uuid,
                                         _secret,
                                         _httpLogLevel ?? Http.HttpLogLevel.NONE,
                                         _loggerProvider);
            }

            /// <summary>
            /// Sets the base URI the client will be using.
            /// </summary>
            /// <param name="baseUri">The base URI.</param>
            /// <returns>This builder for chaining.</returns>
            /// <seealso cref="EnjinHosts"/>
            public ProjectClientBuilder BaseUri(Uri baseUri)
            {
                _baseUri = baseUri;
                return this;
            }

            /// <summary>
            /// Enables the client to automatically authenticate itself.
            /// </summary>
            /// <param name="uuid">The project's UUID.</param>
            /// <param name="secret">The project's secret.</param>
            /// <returns>This builder for chaining.</returns>
            public ProjectClientBuilder EnableAutomaticAuthentication(string uuid, string secret)
            {
                _automaticAuthentication = true;
                _uuid = uuid;
                _secret = secret;
                return this;
            }

            /// <summary>
            /// Sets the log level for HTTP traffic.
            /// </summary>
            /// <param name="logLevel">The log level.</param>
            /// <returns>This builder for chaining.</returns>
            public ProjectClientBuilder HttpLogLevel(HttpLogLevel logLevel)
            {
                _httpLogLevel = logLevel;
                return this;
            }

            /// <summary>
            /// Sets the logger provider for the client to use.
            /// </summary>
            /// <param name="loggerProvider">The logger provider.</param>
            /// <returns>This builder for chaining.</returns>
            public ProjectClientBuilder LoggerProvider(LoggerProvider loggerProvider)
            {
                _loggerProvider = loggerProvider;
                return this;
            }
        }
    }
}