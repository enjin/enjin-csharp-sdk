using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    /// <summary>
    /// Request for resetting the crypto items contract approval for ENJ.
    /// </summary>
    /// <seealso cref="IPlayerSchema"/>
    [PublicAPI]
    public class ResetEnjApproval : GraphqlRequest<ResetEnjApproval>, ITransactionFragmentArguments<ResetEnjApproval>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public ResetEnjApproval() : base("enjin.sdk.player.ResetEnjApproval")
        {
        }
    }
}