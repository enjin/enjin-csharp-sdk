using JetBrains.Annotations;
using Newtonsoft.Json;

namespace EnjinSDK.Models
{
    [PublicAPI]
    public class AccessToken
    {
        [JsonProperty("accessToken")]
        public string Token { get; private set; }
        [JsonProperty("expiresIn")]
        public long ExpiresIn { get; private set; }

        public override string ToString()
        {
            return $"{nameof(Token)}: {Token}, {nameof(ExpiresIn)}: {ExpiresIn}";
        }
    }
}