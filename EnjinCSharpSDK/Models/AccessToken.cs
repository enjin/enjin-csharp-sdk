using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a successful auth object.
    /// </summary>
    [PublicAPI]
    public class AccessToken
    {
        /// <summary>
        /// Represents the token of the auth object.
        /// </summary>
        /// <value>The token for the auth.</value>
        [JsonProperty("accessToken")]
        public string Token { get; private set; }
        
        /// <summary>
        /// Represents the number of seconds until the auth expires.
        /// </summary>
        /// <value>The number of seconds until the auth expires.</value>
        [JsonProperty("expiresIn")]
        public long ExpiresIn { get; private set; }

        /// <summary>
        /// Converts the auth object into a string.
        /// </summary>
        /// <returns>The string format of the auth.</returns>
        public override string ToString()
        {
            return $"{nameof(Token)}: {Token}, {nameof(ExpiresIn)}: {ExpiresIn}";
        }
    }
}