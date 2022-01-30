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
using System.Threading.Tasks;
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
        private string? _uuid;
        private string? _secret;

        // Mutexes
        private readonly object _authMutex = new object();

        /// <summary>
        /// Amount of time in seconds to preempt the expiration period of an access token.
        /// </summary>
        private const int PreemptAuthExpirationTime = 60;

        /// <inheritdoc/>
        public bool IsAuthenticated => Middleware.HttpHandler.IsAuthenticated;

        /// <summary>
        /// Represents whether this client is enabled for automatic authentication.
        /// </summary>
        /// <value>Whether this client is enabled for automatic authentication.</value>
        public bool IsAutomaticReauthenticationEnabled { get; private set; }

        /// <inheritdoc/>
        public bool IsClosed { get; private set; }

        /// <summary>
        /// Represents whether the authentication timer is running.
        /// </summary>
        /// <value>Whether the authentication timer is running.</value>
        public bool IsReauthenticationRunning
        {
            get
            {
                lock (_authMutex)
                {
                    return _authTimer?.Enabled ?? false;
                }
            }
        }

        /// <summary>
        /// Event handler for when the authentication timer is stopped.
        /// </summary>
        public EventHandler? OnAutomaticReauthenticationStopped;

        private ProjectClient(Uri baseUri,
                              bool automaticReauthentication,
                              HttpLogLevel httpLogLevel,
                              LoggerProvider? loggerProvider)
            : base(new TrustedPlatformMiddleware(baseUri, httpLogLevel, loggerProvider), loggerProvider)
        {
            IsAutomaticReauthenticationEnabled = automaticReauthentication;
            if (!IsAutomaticReauthenticationEnabled)
                return;

            _authTimer = new Timer
            {
                AutoReset = false,
            };
            _authTimer.Elapsed += (sender, args) => SendRequestAndAuth();
        }

        /// <inheritdoc/>
        /// <remarks>
        /// If this client has automatic reauthentication enabled, then this method will halt the reauthentication
        /// timer.
        /// </remarks>
        public void Auth(string? token)
        {
            Auth(token, null);
        }

        /// <summary>
        /// Authenticates the client using the given access token model.
        /// </summary>
        /// <param name="accessToken">The access token model.</param>
        /// <exception cref="ArgumentException">
        /// If <paramref name="accessToken"/> is not null and either its <see cref="AccessToken.Token"/> or
        /// <see cref="AccessToken.ExpiresIn"/> properties are null.
        /// </exception>
        /// <remarks>
        /// If this client has automatic reauthentication enabled, then this method may halt the reauthentication timer
        /// when <paramref name="accessToken"/> is <c>null</c>. Otherwise the timer will be restarted.
        /// </remarks>
        public void Auth(AccessToken? accessToken)
        {
            if (accessToken != null && (accessToken.Token == null || accessToken.ExpiresIn == null))
                throw new ArgumentException("Non-null access token has missing token or expiration data.");

            Auth(accessToken?.Token, accessToken?.ExpiresIn);
        }

        /// <summary>
        /// Sends a request to the platform to authenticate this client.
        /// </summary>
        /// <remarks>
        /// If this client is enabled for automatic reauthentication, then it will cache the UUID and secret and
        /// reauthenticate itself before the <see cref="AccessToken"/> returned by the platform expires.
        /// </remarks>
        /// <param name="uuid">The project's UUID.</param>
        /// <param name="secret">The project's secret.</param>
        /// <returns>The task for this operation.</returns>
        /// <exception cref="ArgumentNullException">
        /// If <see cref="IsClosed"/>
        /// If this client is closed at the time this method is called.
        /// </exception>
        public Task AuthClient(string uuid, string secret)
        {
            lock (_authMutex)
            {
                _uuid = uuid ?? throw new ArgumentNullException(nameof(uuid));
                _secret = secret ?? throw new ArgumentNullException(nameof(secret));
            }

            return SendRequestAndAuth(uuid, secret);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            lock (_authMutex)
            {
                _authTimer?.Close();
            }

            Middleware.HttpClient.Dispose();
            IsClosed = true;
        }

        /// <summary>
        /// Sets the auth data for this client.
        /// </summary>
        /// <param name="token">The auth token.</param>
        /// <param name="expiresIn">The time until the auth token expires.</param>
        private void Auth(string? token, long? expiresIn)
        {
            var timerRestarted = false;
            lock (_authMutex)
            {
                if (IsAutomaticReauthenticationEnabled && _uuid != null && _secret != null)
                    timerRestarted = RestartAuthenticationTimer(expiresIn);
            }

            Middleware.HttpHandler.AuthToken = token;

            if (_authTimer != null && !timerRestarted)
                OnAutomaticReauthenticationStopped?.Invoke(this, EventArgs.Empty);
        }

        private bool RestartAuthenticationTimer(long? expiresIn)
        {
            _authTimer!.Stop();

            if (expiresIn == null || expiresIn <= 0)
                return false;

            if (expiresIn - PreemptAuthExpirationTime > 0)
                expiresIn -= PreemptAuthExpirationTime;

            _authTimer.Interval = expiresIn.Value * 1000; // Convert to milliseconds
            _authTimer.Start();

            return true;
        }

        private Task SendRequestAndAuth(string uuid, string secret)
        {
            if (uuid == null) throw new ArgumentNullException(nameof(uuid));
            if (secret == null) throw new ArgumentNullException(nameof(secret));

            var req = new AuthProject().Uuid(uuid).Secret(secret);
            return AuthProject(req).ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    var e = task.Exception!;
                    LoggerProvider?.Log(LogLevel.ERROR, "Automatic AuthProject request failed.", e);
                    throw e;
                }

                var res = task.Result;
                if (res.IsSuccess)
                    Auth(res.Result);
                else
                    Auth(null, null);
            });
        }

        private void SendRequestAndAuth()
        {
            string uuid;
            string secret;
            lock (_authMutex)
            {
                if (_uuid == null || _secret == null)
                    throw new InvalidOperationException("Client cannot authenticate without a UUID and secret.");

                uuid = _uuid;
                secret = _secret;
            }

            SendRequestAndAuth(uuid, secret);
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
            /// Enables the client to automatically reauthenticate itself when authenticated through its
            /// <see cref="ProjectClient.AuthClient"/> method.
            /// </summary>
            /// <returns>This builder for chaining.</returns>
            public ProjectClientBuilder EnableAutomaticReauthentication()
            {
                _automaticAuthentication = true;
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