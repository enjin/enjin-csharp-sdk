using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for releasing the reserve of an item.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class ReleaseReserve : GraphqlRequest<ReleaseReserve>, ITransactionRequestArguments<ReleaseReserve>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public ReleaseReserve() : base("enjin.sdk.project.ReleaseReserve")
        {
        }
        
        /// <summary>
        /// Sets the token (item) ID.
        /// </summary>
        /// <param name="tokenId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public ReleaseReserve TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        /// <summary>
        /// Sets the amount to release.
        /// </summary>
        /// <param name="value">The amount.</param>
        /// <returns>This request for chaining.</returns>
        public ReleaseReserve Value(string value)
        {
            return SetVariable("value", value);
        }
    }
}