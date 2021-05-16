using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for getting player wallets.
    /// </summary>
    /// <seealso cref="Wallet"/>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class GetWallets : GraphqlRequest<GetWallets>,
                              IWalletFragmentArguments<GetWallets>,
                              IPaginationArguments<GetWallets>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetWallets() : base("enjin.sdk.project.GetWallets")
        {
        }

        /// <summary>
        /// Sets the user IDs owning the wallets to get.
        /// </summary>
        /// <param name="userIds">The user IDs.</param>
        /// <returns>This request for chaining.</returns>
        public GetWallets UserIds(params string[]? userIds)
        {
            return SetVariable("userIds", userIds);
        }

        /// <summary>
        /// Sets the Ethereum addresses of the wallets to get.
        /// </summary>
        /// <param name="ethAddresses">The addresses.</param>
        /// <returns>This request for chaining.</returns>
        public GetWallets EthAddresses(params string[]? ethAddresses)
        {
            return SetVariable("ethAddresses", ethAddresses);
        }
    }
}