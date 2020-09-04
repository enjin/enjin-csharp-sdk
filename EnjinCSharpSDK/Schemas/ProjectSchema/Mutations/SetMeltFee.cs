using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for setting the melt fee of an item.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class SetMeltFee : GraphqlRequest<SetMeltFee>, ITransactionRequestArguments<SetMeltFee>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public SetMeltFee() : base("enjin.sdk.project.SetMeltFee")
        {
        }
        
        /// <summary>
        /// Sets the token (item) ID.
        /// </summary>
        /// <param name="tokenId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public SetMeltFee TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        /// <summary>
        /// Sets the index for non-fungible items.
        /// </summary>
        /// <param name="tokenIndex">The index.</param>
        /// <returns>This request for chaining.</returns>
        public SetMeltFee TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }
        
        /// <summary>
        /// Sets the new melt fee for the item.
        /// </summary>
        /// <param name="meltFee">The new ratio.</param>
        /// <returns>This request for chaining.</returns>
        /// <remarks>
        /// The ratio is in the range 0-5000 to allow for fractional ratios, e.g. 1 = 0.01%, 5000 = 50%, ect...
        /// </remarks>
        public SetMeltFee MeltFee(int? meltFee)
        {
            return SetVariable("meltFee", meltFee);
        }
    }
}