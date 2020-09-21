using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a player on a application.
    /// </summary>
    [PublicAPI]
    public class Player
    {
        /// <summary>
        /// Represents the ID of this player.
        /// </summary>
        /// <value>The player ID.</value>
        [JsonProperty("id")]
        public string Id { get; private set; }
        
        /// <summary>
        /// Represents the linking code used to link a wallet to this player.
        /// </summary>
        /// <value>The linking code.</value>
        [JsonProperty("linkingCode")]
        public string LinkingCode { get; private set; }
        
        /// <summary>
        /// Represents the URL for the QR image to be used to link a wallet to this player.
        /// </summary>
        /// <value>The URL for the image.</value>
        [JsonProperty("linkingCodeQr")]
        public string LinkingCodeQr { get; private set; }
        
        /// <summary>
        /// Represents the wallet for this player.
        /// </summary>
        /// <value>The wallet.</value>
        [JsonProperty("wallet")]
        public JObject Wallet { get; private set; }
        
        /// <summary>
        /// Represents the datetime when this player was created.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("createdAt")]
        public string CreatedAt { get; private set; }
        
        /// <summary>
        /// Represents the datetime when this player was last updated.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; private set; }
    }
}