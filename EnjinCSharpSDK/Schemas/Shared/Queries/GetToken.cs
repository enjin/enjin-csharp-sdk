using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for getting a token (item) on the platform.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Models.Token"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class GetToken : GraphqlRequest<GetToken>, ITokenFragmentArguments<GetToken>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetToken() : base("enjin.sdk.shared.GetToken")
        {
        }

        /// <summary>
        /// Sets the token (item) ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public GetToken Id(string id)
        {
            return SetVariable("id", id);
        }
    }
}