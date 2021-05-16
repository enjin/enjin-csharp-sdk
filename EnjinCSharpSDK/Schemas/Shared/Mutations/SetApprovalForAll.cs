using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for allowing an operator complete control of all assets owned by the caller.
    /// </summary>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class SetApprovalForAll : GraphqlRequest<SetApprovalForAll>, ITransactionRequestArguments<SetApprovalForAll>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public SetApprovalForAll() : base("enjin.sdk.shared.SetApprovalForAll")
        {
        }

        /// <summary>
        /// Sets the wallet address of the operator.
        /// </summary>
        /// <param name="operatorAddress">The address.</param>
        /// <returns>This request for chaining.</returns>
        public SetApprovalForAll OperatorAddress(string? operatorAddress)
        {
            return SetVariable("operatorAddress", operatorAddress);
        }

        /// <summary>
        /// Sets the approval state.
        /// </summary>
        /// <param name="approved">The approval.</param>
        /// <returns>This request for chaining.</returns>
        public SetApprovalForAll Approved(bool? approved)
        {
            return SetVariable("approved", approved);
        }
    }
}