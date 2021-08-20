using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for melting a asset.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class MeltAsset : GraphqlRequest<MeltAsset>, IProjectTransactionRequestArguments<MeltAsset>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public MeltAsset() : base("enjin.sdk.project.MeltAsset")
        {
        }

        /// <summary>
        /// Sets the melts to be performed.
        /// </summary>
        /// <param name="melts">The melts.</param>
        /// <returns>This request for chaining.</returns>
        public MeltAsset Melts(params Melt[]? melts)
        {
            return SetVariable("melts", melts);
        }
    }
}