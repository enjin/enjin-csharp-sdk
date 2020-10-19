using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for unlinking a wallet from the application.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class UnlinkPlayerWallet : GraphqlRequest<UnlinkPlayerWallet>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public UnlinkPlayerWallet() : base("enjin.sdk.project.UnlinkPlayerWallet")
        {
        }
        
        /// <summary>
        /// Sets the Ethereum address of the wallet to unlink.
        /// </summary>
        /// <param name="ethAddress">The address.</param>
        /// <returns>This request for chaining.</returns>
        public UnlinkPlayerWallet EthAddress(string ethAddress)
        {
            return SetVariable("ethAddress", ethAddress);
        }
    }
}