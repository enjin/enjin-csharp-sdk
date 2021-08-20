using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for approving the crypto items contracts to spend ENJ.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class ApproveEnj : GraphqlRequest<ApproveEnj>, IProjectTransactionRequestArguments<ApproveEnj>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public ApproveEnj() : base("enjin.sdk.project.ApproveEnj")
        {
        }

        /// <summary>
        /// Sets the amount of ENJ to approve.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>This request for chaining.</returns>
        /// <remarks>
        /// The value is in Wei as 10^18 (e.g. 1 ENJ = 1000000000000000000).
        /// </remarks>
        public ApproveEnj Value(string? value)
        {
            return SetVariable("value", value);
        }
    }
}