using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request for getting a project on the platform.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Models.Project"/>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class GetProject : GraphqlRequest<GetProject>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetProject() : base("enjin.sdk.shared.GetProject")
        {
        }

        /// <summary>
        /// Sets the project ID.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public GetProject Id(int? id)
        {
            return SetVariable("id", id);
        }

        /// <summary>
        /// Sets the project name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>This request for chaining.</returns>
        public GetProject Name(string? name)
        {
            return SetVariable("name", name);
        }
    }
}