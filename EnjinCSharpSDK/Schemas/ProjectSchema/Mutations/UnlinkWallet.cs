using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for unlinking a wallet from the project.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class UnlinkWallet : GraphqlRequest<UnlinkWallet>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public UnlinkWallet() : base("enjin.sdk.project.UnlinkWallet")
        {
        }
        
        /// <summary>
        /// Sets the Ethereum address of the wallet to unlink.
        /// </summary>
        /// <param name="ethAddress">The address.</param>
        /// <returns>This request for chaining.</returns>
        public UnlinkWallet EthAddress(string? ethAddress)
        {
            return SetVariable("ethAddress", ethAddress);
        }
    }
}