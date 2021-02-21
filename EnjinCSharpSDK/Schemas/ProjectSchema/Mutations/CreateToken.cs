using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request for creating a token (item) on the platform.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class CreateToken : GraphqlRequest<CreateToken>, ITransactionRequestArguments<CreateToken>
    {
        /// <summary>
        /// Sole constructor.
        /// </summary>
        public CreateToken() : base("enjin.sdk.project.CreateToken")
        {
        }
        
        /// <summary>
        /// Sets the name of the token (item).
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>This request for chaining.</returns>
        public CreateToken Name(string name)
        {
            return SetVariable("name", name);
        }
        
        /// <summary>
        /// Sets the total supply of the token (item).
        /// </summary>
        /// <param name="totalSupply">The total supply.</param>
        /// <returns>This request for chaining.</returns>
        public CreateToken TotalSupply(string totalSupply)
        {
            return SetVariable("totalSupply", totalSupply);
        }
        
        /// <summary>
        /// Sets the initial reserve of the token (item).
        /// </summary>
        /// <param name="initialReserve">The reserve.</param>
        /// <returns>This request for chaining.</returns>
        public CreateToken InitialReserve(string initialReserve)
        {
            return SetVariable("initialReserve", initialReserve);
        }
        
        /// <summary>
        /// Sets the supply model of the token (item).
        /// </summary>
        /// <param name="supplyModel">The model.</param>
        /// <returns>This request for chaining.</returns>
        public CreateToken SupplyModel(TokenSupplyModel? supplyModel)
        {
            return SetVariable("supplyModel", supplyModel);
        }
        
        /// <summary>
        /// Sets the melt value of the token (item). This value corresponds to its exchange rate.
        /// </summary>
        /// <param name="meltValue">The value.</param>
        /// <returns>This request for chaining.</returns>
        public CreateToken MeltValue(string meltValue)
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
        public CreateToken MeltFeeRatio(int? meltFeeRatio)
        {
            return SetVariable("meltFeeRatio", meltFeeRatio);
        }
        
        /// <summary>
        /// Sets the transferable type of the token (item).
        /// </summary>
        /// <param name="transferable">The transferable type.</param>
        /// <returns>This request for chaining.</returns>
        public CreateToken Transferable(TokenTransferable? transferable)
        {
            return SetVariable("transferable", transferable);
        }
        
        /// <summary>
        /// Sets the transfer fee settings of the token (item).
        /// </summary>
        /// <param name="transferFeeSettings">The settings.</param>
        /// <returns>This request for chaining.</returns>
        public CreateToken TransferFeeSettings(TokenTransferFeeSettingsInput transferFeeSettings)
        {
            return SetVariable("transferFeeSettings", transferFeeSettings);
        }
        
        /// <summary>
        /// Sets the fungible state of the token (item).
        /// </summary>
        /// <param name="nonFungible">The state.</param>
        /// <returns>This request for chaining.</returns>
        public CreateToken NonFungible(bool? nonFungible)
        {
            return SetVariable("nonFungible", nonFungible);
        }
    }
}