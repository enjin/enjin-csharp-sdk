using System.Collections.Generic;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for minting a asset.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class MintAsset : GraphqlRequest<MintAsset>, ITransactionRequestArguments<MintAsset>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public MintAsset() : base("enjin.sdk.project.MintAsset")
        {
        }
        
        /// <summary>
        /// Sets the asset ID.
        /// </summary>
        /// <param name="assetId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public MintAsset AssetId(string? assetId)
        {
            return SetVariable("assetId", assetId);
        }
        
        /// <summary>
        /// Sets the mints to be performed.
        /// </summary>
        /// <param name="mints">The mints.</param>
        /// <returns>This request for chaining.</returns>
        public MintAsset Mints(params MintInput[]? mints)
        {
            return SetVariable("mints", mints);
        }
    }
}