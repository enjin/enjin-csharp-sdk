using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for getting a player's wallet.
    /// </summary>
    /// <seealso cref="Wallet"/>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class GetWallet : GraphqlRequest<GetWallet>, IWalletFragmentArguments<GetWallet>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetWallet() : base("enjin.sdk.project.GetWallet")
        {
        }

        /// <summary>
        /// Sets the user ID owning the wallet to get.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <returns>This request for chaining.</returns>
        public GetWallet UserId(string? userId)
        {
            return SetVariable("userId", userId);
        }
        
        /// <summary>
        /// Sets the Ethereum address of the wallet to get.
        /// </summary>
        /// <param name="ethAddress">The address.</param>
        /// <returns>This request for chaining.</returns>
        public GetWallet EthAddress(string? ethAddress)
        {
            return SetVariable("ethAddress", ethAddress);
        }
    }
}