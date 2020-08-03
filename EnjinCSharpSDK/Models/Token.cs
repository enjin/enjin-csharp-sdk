using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class Token
    {
        [JsonProperty("id")]
        public string Id { get; private set; }
        
        [JsonProperty("name")]
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
}