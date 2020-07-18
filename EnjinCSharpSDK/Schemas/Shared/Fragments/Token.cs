using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class Token
    {
        public string Id { get; private set; }
        
        public string Name { get; private set; }
        
        [JsonProperty("blockHeight")]
        public int BlockHeight { get; private set; }
        
        [JsonProperty("creator")]
        public string Creator { get; private set; }
        
        [JsonProperty("firstBlock")]
        public int FirstBlock { get; private set; }
        
        [JsonProperty("meltFeeRatio")]
        public int MeltFeeRatio { get; private set; }
        
        [JsonProperty("meltFeeMaxRatio")]
        public int MeltFeeMaxRatio { get; private set; }
        
        [JsonProperty("meltValue")]
        public string MeltValue { get; private set; }
        
        [JsonProperty("metadataUri")]
        public string MetadataUri { get; private set; }
        
        [JsonProperty("nonfungible")]
        public bool Nonfungible { get; private set; }
        
        [JsonProperty("reserve")]
        public string Reserve { get; private set; }
        
        [JsonProperty("supplyModel")]
        public TokenSupplyModel SupplyModel { get; private set; }
        
        [JsonProperty("circulatingSupply")]
        public string CirculatingSupply { get; private set; }
        
        [JsonProperty("mintableSupply")]
        public string MintableSupply { get; private set; }
        
        [JsonProperty("totalSupply")]
        public string TotalSupply { get; private set; }
        
        [JsonProperty("transferable")]
        public TokenTransferable Transferable { get; private set; }
        
        [JsonProperty("transferFeeSettings")]
        public TokenTransferFeeSettings TransferFeeSettings { get; private set; }
        
        [JsonProperty("variantMode")]
        public TokenVariantMode VariantMode { get; private set; }
        
        [JsonProperty("variants")]
        public List<TokenVariant> Variants { get; private set; }
    }

    [PublicAPI]
    public enum TokenSupplyModel
    {
        FIXED,
        SETTABLE,
        INFINITE,
        COLLAPSING,
        ANNUAL_VALUE,
        ANNUAL_PERCENTAGE
    }

    [PublicAPI]
    public enum TokenTransferable
    {
        PERMANENT,
        TEMPORARY,
        BOUND
    }

    [PublicAPI]
    public class TokenTransferFeeSettings
    {
        [JsonProperty("type")]
        public TokenTransferFeeType Type { get; private set; }
        
        [JsonProperty("tokenId")]
        public string TokenId { get; private set; }
        
        [JsonProperty("value")]
        public string Value { get; private set; }
    }

    [PublicAPI]
    public enum TokenTransferFeeType
    {
        NONE,
        PER_TRANSFER,
        PER_CRYPTO_ITEM,
        RATIO_CUT,
        RATIO_EXTRA
    }

    [PublicAPI]
    public enum TokenVariantMode
    {
        NONE,
        BEAM,
        ONCE,
        ALWAYS
    }

    [PublicAPI]
    public class TokenVariant
    {
        [JsonProperty("id")]
        public int Id { get; private set; }
        
        [JsonProperty("tokenId")]
        public string TokenId { get; private set; }
        
        [JsonProperty("variantMetadata")]
        public JObject VariantMetadata { get; private set; }
        
        [JsonProperty("usageCount")]
        public int UsageCount { get; private set; }
        
        [JsonProperty("createdAt")]
        public string CreatedAt { get; private set; }
        
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; private set; }
    }
}