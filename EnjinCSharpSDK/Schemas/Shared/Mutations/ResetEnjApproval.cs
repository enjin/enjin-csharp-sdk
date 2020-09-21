using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for resetting the crypto items contract approval for ENJ.
    /// </summary>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class ResetEnjApproval : GraphqlRequest<ResetEnjApproval>, ITransactionRequestArguments<ResetEnjApproval>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public ResetEnjApproval() : base("enjin.sdk.shared.ResetEnjApproval")
        {
        }
    }
}