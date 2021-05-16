using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for approving the crypto items contracts to spend ENJ.
    /// </summary>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class ApproveEnj : GraphqlRequest<ApproveEnj>, ITransactionRequestArguments<ApproveEnj>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public ApproveEnj() : base("enjin.sdk.shared.ApproveEnj")
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