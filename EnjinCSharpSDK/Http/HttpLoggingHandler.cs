using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Enjin.SDK.Http
{
    public class HttpLoggingHandler : DelegatingHandler
    {
        private readonly string[] _types = {"html", "text", "xml", "json", "txt", "x-www-form-urlencoded"};

        public HttpLoggingHandler(HttpMessageHandler innerHandler = null) : base(
            innerHandler ?? new HttpClientHandler())
        {
        }

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