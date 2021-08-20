using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    /// <summary>
    /// Request for approving the crypto items contract to spend the maximum amount of ENJ.
    /// </summary>
    /// <seealso cref="IPlayerSchema"/>
    [PublicAPI]
    public class ApproveMaxEnj : GraphqlRequest<ApproveMaxEnj>, ITransactionFragmentArguments<ApproveMaxEnj>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public ApproveMaxEnj() : base("enjin.sdk.player.ApproveMaxEnj")
        {
        }
    }
}