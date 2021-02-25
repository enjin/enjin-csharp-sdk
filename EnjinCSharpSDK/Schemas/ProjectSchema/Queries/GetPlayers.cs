using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for getting players on the project.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Models.Player"/>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class GetPlayers
        : GraphqlRequest<GetPlayers>, IPaginationArguments<GetPlayers>, IPlayerFragmentArguments<GetPlayers>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public GetPlayers() : base("enjin.sdk.project.GetPlayers")
        {
        }

        /// <summary>
        /// Sets the filter the request will use.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>This request for chaining.</returns>
        public GetPlayers Filter(PlayerFilter filter)
        {
            return SetVariable("filter", filter);
        }
    }
}