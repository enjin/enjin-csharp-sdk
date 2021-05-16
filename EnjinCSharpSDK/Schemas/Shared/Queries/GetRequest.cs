using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for getting a transaction on platform.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Models.Request"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class GetRequest : GraphqlRequest<GetRequest>, ITransactionFragmentArguments<GetRequest>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetRequest() : base("enjin.sdk.shared.GetRequest")
        {
        }

        /// <summary>
        /// Sets the transaction ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public GetRequest Id(int? id)
        {
            return SetVariable("id", id);
        }

        /// <summary>
        /// Sets the transaction hash ID.
        /// </summary>
        /// <param name="id">The hash ID.</param>
        /// <returns>This request for chaining.</returns>
        public GetRequest TransactionId(string? id)
        {
            return SetVariable("transactionId", id);
        }
    }
}