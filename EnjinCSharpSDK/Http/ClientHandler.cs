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

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Enjin.SDK.Http
{
    /// <summary>
    /// HTTP handler for platform clients.
    /// </summary>
    public class ClientHandler : DelegatingHandler
    {
        private string? _authToken;

        // Mutexes
        private readonly object _authMutex = new object();

        /// <summary>
        /// Creates a new instance of the <see cref="ClientHandler"/> class with a specific inner handler.
        /// </summary>
        /// <param name="innerHandler">
        /// The inner handler which is responsible for processing the HTTP response messages.
        /// </param>
        public ClientHandler(HttpMessageHandler innerHandler) : base(innerHandler)
        {
        }

        /// <summary>
        /// Represents the authentication token for the client.
        /// </summary>
        /// <value>The auth token.</value>
        public string? AuthToken
        {
            set
            {
                lock (_authMutex)
                    _authToken = value;
            }
        }

        /// <summary>
        /// Represents if the client is authenticated.
        /// </summary>
        /// <value>Whether the SDK is authenticated.</value>
        public bool IsAuthenticated
        {
            get
            {
                lock (_authMutex)
                    return !string.IsNullOrWhiteSpace(_authToken);
            }
        }

        /// <inheritdoc/>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken)
        {
            lock (_authMutex)
            {
                if (IsAuthenticated)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
                }
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}