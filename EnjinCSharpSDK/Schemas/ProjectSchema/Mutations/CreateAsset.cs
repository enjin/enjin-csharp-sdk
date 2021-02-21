using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for creating a asset on the platform.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class CreateAsset : GraphqlRequest<CreateAsset>, ITransactionRequestArguments<CreateAsset>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public CreateAsset() : base("enjin.sdk.project.CreateAsset")
        {
        }
        
        /// <summary>
        /// Sets the name of the asset.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>This request for chaining.</returns>
        public CreateAsset Name(string name)
        {
            return SetVariable("name", name);
        }
        
        /// <summary>
        /// Sets the total supply of the asset.
        /// </summary>
        /// <param name="totalSupply">The total supply.</param>
        /// <returns>This request for chaining.</returns>
        public CreateAsset TotalSupply(string totalSupply)
        {
            return SetVariable("totalSupply", totalSupply);
        }
        
        /// <summary>
        /// Sets the initial reserve of the asset.
        /// </summary>
        /// <param name="initialReserve">The reserve.</param>
        /// <returns>This request for chaining.</returns>
        public CreateAsset InitialReserve(string initialReserve)
        {
            return SetVariable("initialReserve", initialReserve);
        }
        
        /// <summary>
        /// Sets the supply model of the asset.
        /// </summary>
        /// <param name="supplyModel">The model.</param>
        /// <returns>This request for chaining.</returns>
        public CreateAsset SupplyModel(AssetSupplyModel? supplyModel)
        {
            return SetVariable("supplyModel", supplyModel);
        }
        
        /// <summary>
        /// Sets the melt value of the asset. This value corresponds to its exchange rate.
        /// </summary>
        /// <param name="meltValue">The value.</param>
        /// <returns>This request for chaining.</returns>
        public CreateAsset MeltValue(string meltValue)
        {
            return SetVariable("meltValue", meltValue);
        }
        
        /// <summary>
        /// Sets the ratio of the melt value to be returned to the creator.
        /// </summary>
        /// <param name="meltFeeRatio">The ratio.</param>
        /// <returns>This request for chaining.</returns>
        /// <remarks>
        /// The ratio is in the range 0-5000 to allow for fractional ratios, e.g. 1 = 0.01%, 5000 = 50%, ect...
        /// </remarks>
        public CreateAsset MeltFeeRatio(int? meltFeeRatio)
        {
            return SetVariable("meltFeeRatio", meltFeeRatio);
        }
        
        /// <summary>
        /// Sets the transferable type of the asset.
        /// </summary>
        /// <param name="transferable">The transferable type.</param>
        /// <returns>This request for chaining.</returns>
        public CreateAsset Transferable(AssetTransferable? transferable)
        {
            return SetVariable("transferable", transferable);
        }
        
        /// <summary>
        /// Sets the transfer fee settings of the asset.
        /// </summary>
        /// <param name="transferFeeSettings">The settings.</param>
        /// <returns>This request for chaining.</returns>
        public CreateAsset TransferFeeSettings(AssetTransferFeeSettingsInput transferFeeSettings)
        {
            return SetVariable("transferFeeSettings", transferFeeSettings);
        }
        
        /// <summary>
        /// Sets the fungible state of the asset.
        /// </summary>
        /// <param name="nonFungible">The state.</param>
        /// <returns>This request for chaining.</returns>
        public CreateAsset NonFungible(bool? nonFungible)
        {
            return SetVariable("nonFungible", nonFungible);
        }
    }
}