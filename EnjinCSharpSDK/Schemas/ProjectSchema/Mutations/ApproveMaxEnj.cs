using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for approving the crypto items contract to spend the maximum amount of ENJ.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class ApproveMaxEnj : GraphqlRequest<ApproveMaxEnj>, IProjectTransactionRequestArguments<ApproveMaxEnj>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public ApproveMaxEnj() : base("enjin.sdk.project.ApproveMaxEnj")
        {
        }
    }
}