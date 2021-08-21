using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for resetting the crypto items contract approval for ENJ.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class ResetEnjApproval : GraphqlRequest<ResetEnjApproval>, IProjectTransactionRequestArguments<ResetEnjApproval>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public ResetEnjApproval() : base("enjin.sdk.project.ResetEnjApproval")
        {
        }
    }
}