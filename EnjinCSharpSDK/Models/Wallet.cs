using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a wallet on the platform.
    /// </summary>
    [PublicAPI]
    public class Wallet
    {
        /// <summary>
        /// Represents the Ethereum address of this wallet.
        /// </summary>
        /// <value>The address.</value>
        [JsonProperty("ethAddress")]
        public string EthAddress { get; private set; }
        
        /// <summary>
        /// Represents the ENJ allowance given to crypto items.
        /// </summary>
        /// <value>The allowance.</value>
        [JsonProperty("enjAllowance")]
        public float EnjAllowance { get; private set; }
        
        /// <summary>
        /// Represents the ENJ balance for this wallet.
        /// </summary>
        /// <value>The balance.</value>
        [JsonProperty("enjBalance")]
        public float EnjBalance { get; private set; }
        
        /// <summary>
        /// Represents the ETH balance for this wallet.
        /// </summary>
        /// <value>The balance.</value>
        [JsonProperty("ethBalance")]
        public float EthBalance { get; private set; }
        
        /// <summary>
        /// Represents the assets this wallet has created.
        /// </summary>
        /// <value>The list of assets.</value>
        [JsonProperty("assetsCreated")]
        public List<Asset> AssetsCreated { get; private set; }
    }
}