using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace EnjinSDK.Http
{
    public class TrustedPlatformHandler : HttpClientHandler
    {
        private string _authToken;

        public string AuthToken
        {
            set => _authToken = value;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrWhiteSpace(_authToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _authToken);
            }
            
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}