using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for approving the crypto items contract to spend the maximum amount of ENJ.
    /// </summary>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class ApproveMaxEnj : GraphqlRequest<ApproveMaxEnj>, ITransactionRequestArguments<ApproveMaxEnj>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public ApproveMaxEnj() : base("enjin.sdk.shared.ApproveMaxEnj")
        {
        }
    }
}