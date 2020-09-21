using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for setting an item's max melt fee to a lower value.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class DecreaseMaxMeltFee : GraphqlRequest<DecreaseMaxMeltFee>, ITransactionRequestArguments<DecreaseMaxMeltFee>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public DecreaseMaxMeltFee() : base("enjin.sdk.project.DecreaseMaxMeltFee")
        {
        }
        
        /// <summary>
        /// Sets the token (item) ID.
        /// </summary>
        /// <param name="tokenId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public DecreaseMaxMeltFee TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        /// <summary>
        /// Sets the index for non-fungible items.
        /// </summary>
        /// <param name="tokenIndex">The index.</param>
        /// <returns>This request for chaining.</returns>
        public DecreaseMaxMeltFee TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }
        
        /// <summary>
        /// Sets the new max melt fee for the item.
        /// </summary>
        /// <param name="maxMeltFee">The new ratio.</param>
        /// <returns>This request for chaining.</returns>
        /// <remarks>
        /// The ratio is in the range 0-5000 to allow fractional ratios, e.g. 1 = 0.01%, 5000 = 50%, ect...
        /// </remarks>
        public DecreaseMaxMeltFee MaxMeltFee(int? maxMeltFee)
        {
            return SetVariable("maxMeltFee", maxMeltFee);
        }
    }
}