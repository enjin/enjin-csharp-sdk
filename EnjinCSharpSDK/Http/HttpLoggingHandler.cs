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
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Enjin.SDK.Utils;

namespace Enjin.SDK.Http
{
    /// <summary>
    /// Handler used for debugging the HTTP client.
    /// </summary>
    internal class HttpLoggingHandler : DelegatingHandler
    {
        private readonly HttpLogLevel _logLevel;
        private readonly LoggerProvider _loggerProvider;

        /// <summary>
        /// Creates a new instance of the <see cref="HttpLoggingHandler"/> class with a specific inner handler.
        /// </summary>
        /// <param name="logLevel">The HTTP logging level.</param>
        /// <param name="loggerProvider">The logger provider.</param>
        /// <param name="innerHandler">
        /// The inner handler which is responsible for processing the HTTP response messages.
        /// </param>
        internal HttpLoggingHandler(HttpLogLevel logLevel,
                                    LoggerProvider loggerProvider,
                                    HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
            _logLevel = logLevel;
            _loggerProvider = loggerProvider ?? throw new ArgumentNullException(nameof(loggerProvider));
        }

        /// <inheritdoc/>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                     CancellationToken cancellationToken)
        {
            LogRequest(request);

            var start = DateTimeOffset.Now;
            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            var end = DateTimeOffset.Now;

            LogResponse(response, (end - start).Milliseconds);

            return response;
        }

        private void LogRequest(HttpRequestMessage msg)
        {
            if (_logLevel == HttpLogLevel.NONE)
                return;

            var builder = new StringBuilder();
            var method = msg.Method.Method.ToUpper();
            var uri = msg.RequestUri;
            var contentLength = msg.Content.Headers.ContentLength;

            // Line
            if (_logLevel == HttpLogLevel.BASIC)
            {
                builder.AppendLine($"--> {method} {uri} ({contentLength}-byte body)");
                _loggerProvider.Debug(builder.ToString());
                return;
            }

            builder.AppendLine($"--> {method} {uri}");

            // Headers
            foreach (var header in msg.Headers)
            {
                var key = header.Key;
                var values = header.Value;
                if (key == null || values == null)
                    continue;

                builder.AppendLine(key.Equals("User-Agent")
                                       ? $"{key}: {string.Join(" ", values)}"
                                       : $"{key}: {string.Join(", ", values)}");
            }

            if (_logLevel == HttpLogLevel.HEADERS)
            {
                builder.AppendLine($"<-- END {method}");
                _loggerProvider.Debug(builder.ToString());
                return;
            }

            // Body
            builder.AppendLine() // Line break between headers and body
                   .AppendLine(msg.Content.ReadAsStringAsync().Result)
                   .AppendLine($"<-- END {method} ({contentLength}-byte body)");

            _loggerProvider.Debug(builder.ToString());
        }

        private void LogResponse(HttpResponseMessage msg, int rtt)
        {
            if (_logLevel == HttpLogLevel.NONE)
                return;

            var builder = new StringBuilder();
            var status = (int) msg.StatusCode;
            var uri = msg.RequestMessage.RequestUri;

            // Line
            builder.AppendLine($"<-- {status} {uri} ({rtt}ms)");

            if (_logLevel == HttpLogLevel.BASIC)
            {
                _loggerProvider.Debug(builder.ToString());
                return;
            }

            // Headers
            foreach (var header in msg.Headers)
            {
                var key = header.Key;
                var values = header.Value;
                if (key == null || values == null)
                    continue;

                builder.AppendLine($"{key}: {string.Join(", ", values)}");
            }

            if (_logLevel == HttpLogLevel.HEADERS)
            {
                builder.AppendLine("<-- END HTTP");
                _loggerProvider.Debug(builder.ToString());
                return;
            }

            // Body
            builder.AppendLine() // Line break between headers and body
                   .AppendLine(msg.Content.ReadAsStringAsync().Result)
                   .AppendLine("<-- END HTTP");

            _loggerProvider.Debug(builder.ToString());
        }
    }
}