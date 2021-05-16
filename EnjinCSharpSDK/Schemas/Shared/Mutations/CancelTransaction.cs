using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for canceling a transaction on the platform.
    /// </summary>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class CancelTransaction : GraphqlRequest<CancelTransaction>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public CancelTransaction() : base("enjin.sdk.shared.CancelTransaction")
        {
        }

        /// <summary>
        /// Sets the ID of the transaction to cancel.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public CancelTransaction Id(int? id)
        {
            return SetVariable("id", id);
        }
    }
}