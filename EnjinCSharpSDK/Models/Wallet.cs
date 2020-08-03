using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public class Wallet
    {
        [JsonProperty("ethAddress")]
        public string EthAddress { get; private set; }
        
        [JsonProperty("enjAllowance")]
        public float EnjAllowance { get; private set; }
        
        [JsonProperty("enjBalance")]
        public float EnjBalance { get; private set; }
        
        [JsonProperty("ethBalance")]
        public float EthBalance { get; private set; }
        
        [JsonProperty("tokensCreated")]
        public List<Token> TokensCreated { get; private set; }
    }
}