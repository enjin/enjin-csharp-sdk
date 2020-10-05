using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models the linking information of a <see cref="Player"/>.
    /// </summary>
    [PublicAPI]
    public class LinkingInfo
    {
        /// <summary>
        /// Represents the linking code used to link a wallet to the player this information applies to.
        /// </summary>
        /// <value>The linking code.</value>
        [JsonProperty("code")]
        public string Code { get; private set; } = null!;
        
        /// <summary>
        /// Represents the URL for the QR image to be used to link a wallet to the player this information applies to.
        /// </summary>
        /// <value>The URL for the image.</value>
        [JsonProperty("qr")]
        public string Qr { get; private set; } = null!;
    }
}