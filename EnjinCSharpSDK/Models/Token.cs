using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a item on the platform.
    /// </summary>
    [PublicAPI]
    public class Token
    {
        /// <summary>
        /// Represents the base ID of this item.
        /// </summary>
        /// <value>The ID.</value>
        [JsonProperty("id")]
        public string Id { get; private set; }
        
        /// <summary>
        /// Represents the name of this item.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; private set; }
        
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
        public string Creator { get; private set; }
        
        /// <summary>
        /// Represents the first block this item appeared in.
        /// </summary>
        /// <value>The block number.</value>
        [JsonProperty("firstBlock")]
        public int? FirstBlock { get; private set; }
        
        /// <summary>
        /// Represents the melt fee ratio of this item.
        /// </summary>
        /// <value>The ratio.</value>
        /// <remarks>
        /// The ratio is in the range of 0-10000 to allow for fractional ratios. e.g. 1 = 0.01%, 10000 = 100%, ect...
        /// </remarks>
        [JsonProperty("meltFeeRatio")]
        public int? MeltFeeRatio { get; private set; }
        
        /// <summary>
        /// Represents the max melt fee ratio for this item.
        /// </summary>
        /// <value>The ratio.</value>
        /// <remarks>
        /// The ratio is in the range of 0-10000 to allow for fractional ratios. e.g. 1 = 0.01%, 10000 = 100%, ect...
        /// </remarks>
        [JsonProperty("meltFeeMaxRatio")]
        public int? MeltFeeMaxRatio { get; private set; }
        
        /// <summary>
        /// The melt value for this item. This value corresponds to its exchange rate.
        /// </summary>
        /// <value>The melt value.</value>
        [JsonProperty("meltValue")]
        public string MeltValue { get; private set; }
        
        /// <summary>
        /// Represents the URI for the metadata of this item.
        /// </summary>
        /// <value>The URI.</value>
        [JsonProperty("metadataUri")]
        public string MetadataUri { get; private set; }
        
        /// <summary>
        /// Represents the fungible state of this item.
        /// </summary>
        /// <value>Whether this item is non-fungible.</value>
        [JsonProperty("nonfungible")]
        public bool Nonfungible { get; private set; }
        
        /// <summary>
        /// Represents the reserve of this item.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("reserve")]
        public string Reserve { get; private set; }
        
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
        public string CirculatingSupply { get; private set; }
        
        /// <summary>
        /// Represents the amount of this item available for minting.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("mintableSupply")]
        public string MintableSupply { get; private set; }
        
        /// <summary>
        /// Represents the total supply of this item.
        /// </summary>
        /// <value>The amount.</value>
        [JsonProperty("totalSupply")]
        public string TotalSupply { get; private set; }
        
        /// <summary>
        /// Represents the transferable type of this item.
        /// </summary>
        /// <value>The type.</value>
        [JsonProperty("transferable")]
        public TokenTransferable? Transferable { get; private set; }
        
        /// <summary>
        /// Represents the transfer fee settings for this item.
        /// </summary>
        /// <value>The settings.</value>
        [JsonProperty("transferFeeSettings")]
        public TokenTransferFeeSettings TransferFeeSettings { get; private set; }
        
        /// <summary>
        /// Represents the token variant mode of this item.
        /// </summary>
        /// <value>The variant mode.</value>
        [JsonProperty("variantMode")]
        public TokenVariantMode? VariantMode { get; private set; }
        
        /// <summary>
        /// Represents token variants of this item.
        /// </summary>
        /// <value>The variants.</value>
        [JsonProperty("variants")]
        public List<TokenVariant> Variants { get; private set; }
    }
}