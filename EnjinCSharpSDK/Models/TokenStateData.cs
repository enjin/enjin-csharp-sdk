using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models the state data of a <see cref="Token"/>.
    /// </summary>
    [PublicAPI]
    public class TokenStateData
    {
        /// <summary>
        /// Represents the fungible state of this item.
        /// </summary>
        /// <value>Whether this item is non-fungible.</value>
        [JsonProperty("nonfungible")]
        public bool Nonfungible { get; private set; }
        
        /// <summary>
        /// Represents the block number of the last update.
        /// </summary>
        /// <value>The block number.</value>
        [JsonProperty("blockHeight")]
        public int? BlockHeight { get; private set; }
        
        /// <summary>
        /// Represents the wallet address of the creator of this item.
        /// </summary>
        /// <value>The creator's address.</value>
        [JsonProperty("creator")]
        public string? Creator { get; private set; }
        
        /// <summary>
        /// Represents the first block this item appeared in.
        /// </summary>
        /// <value>The block number.</value>
        [JsonProperty("firstBlock")]
        public int? FirstBlock { get; private set; }

        /// <summary>
        /// Represents the reserve of this item.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("reserve")]
        public string? Reserve { get; private set; }
        
        /// <summary>
        /// Represents the supply model for this item.
        /// </summary>
        /// <value>The supply model.</value>
        [JsonProperty("supplyModel")]
        public TokenSupplyModel? SupplyModel { get; private set; }
        
        /// <summary>
        /// Represents the amount of this item in circulation.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("circulatingSupply")]
        public string? CirculatingSupply { get; private set; }
        
        /// <summary>
        /// Represents the amount of this item available for minting.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("mintableSupply")]
        public string? MintableSupply { get; private set; }
        
        /// <summary>
        /// Represents the total supply of this item.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("totalSupply")]
        public string? TotalSupply { get; private set; }
    }
}