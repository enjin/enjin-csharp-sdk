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
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Enjin.SDK.Http
{
    /// <summary>
    /// Handler used for debugging the HTTP client.
    /// </summary>
    public class HttpLoggingHandler : DelegatingHandler
    {
        private readonly string[] _types = {"html", "text", "xml", "json", "txt", "x-www-form-urlencoded"};

        /// <summary>
        /// Constructs the handler with an optional inner handler.
        /// </summary>
        /// <param name="innerHandler">The handler to replace the default client handler.</param>
        public HttpLoggingHandler(HttpMessageHandler? innerHandler = null)
            : base(innerHandler ?? new HttpClientHandler())
        {
        }

        /// <inheritdoc/>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var req = request;
            var id = Guid.NewGuid().ToString();
            var msg = $"[{id} -   Request]";

            Console.Out.WriteLine($"{msg}========Start==========");
            Console.Out.WriteLine(
                $"{msg} {req.Method} {req.RequestUri.PathAndQuery} {req.RequestUri.Scheme}/{req.Version}");
            Console.Out.WriteLine($"{msg} Host: {req.RequestUri.Scheme}://{req.RequestUri.Host}");

            foreach (var header in req.Headers)
                Console.Out.WriteLine($"{msg} {header.Key}: {string.Join(" ", header.Value)}");

            if (req.Content != null)
            {
                foreach (var header in req.Content.Headers)
                    Console.Out.WriteLine($"{msg} {header.Key}: {string.Join(" ", header.Value)}");

                if (req.Content is StringContent || this.IsTextBasedContentType(req.Headers) ||
                    this.IsTextBasedContentType(req.Content.Headers))
                {
                    var result = await req.Content.ReadAsStringAsync();

                    Console.Out.WriteLine($"{msg} Content:");
                    Console.Out.WriteLine($"{msg} {string.Join("", result)}");
                }
            }

            var start = DateTime.Now;

            var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);

            var end = DateTime.Now;

            Console.Out.WriteLine($"{msg} Duration: {end - start}");
            Console.Out.WriteLine($"{msg}==========End==========");

            msg = $"[{id} - Response]";
            Console.Out.WriteLine($"{msg}=========Start=========");

            var resp = response;

            Console.Out.WriteLine(
                $"{msg} {req.RequestUri.Scheme.ToUpper()}/{resp.Version} {(int) resp.StatusCode} {resp.ReasonPhrase}");

            foreach (var header in resp.Headers)
                Console.Out.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");

            if (resp.Content != null)
            {
                foreach (var header in resp.Content.Headers)
                    Console.Out.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");

                if (resp.Content is StringContent || this.IsTextBasedContentType(resp.Headers) ||
                    this.IsTextBasedContentType(resp.Content.Headers))
                {
                    start = DateTime.Now;
                    var result = await resp.Content.ReadAsStringAsync();
                    end = DateTime.Now;

                    Console.Out.WriteLine($"{msg} Content:");
                    Console.Out.WriteLine($"{msg} {string.Join("", result)}");
                    Console.Out.WriteLine($"{msg} Duration: {end - start}");
                }
            }

            Console.Out.WriteLine($"{msg}==========End==========");
            return response;
        }

        private bool IsTextBasedContentType(HttpHeaders headers)
        {
            if (!headers.TryGetValues("Content-Type", out var values))
                return false;
            var header = string.Join(" ", values).ToLowerInvariant();

            return _types.Any(t => header.Contains(t));
        }
    }
}