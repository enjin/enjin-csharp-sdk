using System;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class CreateToken : GraphqlRequest<CreateToken>, ITransactionRequestArguments<CreateToken>
    {
        protected CreateToken() : base("enjin.sdk.project.CreateToken")
        {
        }
        
        public CreateToken Name(string name)
        {
            return SetVariable("name", name);
        }
        
        public CreateToken TotalSupply(string totalSupply)
        {
            return SetVariable("totalSupply", totalSupply);
        }
        
        public CreateToken InitialReserve(string initialReserve)
        {
            return SetVariable("initialReserve", initialReserve);
        }
        
        public CreateToken SupplyModel(TokenSupplyModel supplyModel)
        {
            return SetVariable("supplyModel", supplyModel);
        }
        
        public CreateToken MeltValue(string meltValue)
        {
            return SetVariable("meltValue", meltValue);
        }
        
        public CreateToken MeltFeeRatio(int meltFeeRatio)
        {
            return SetVariable("meltFeeRatio", meltFeeRatio);
        }
        
        public CreateToken Transferable(TokenTransferable transferable)
        {
            return SetVariable("transferable", transferable);
        }
        
        public CreateToken TransferFeeSettings(TokenTransferFeeSettingsInput transferFeeSettings)
        {
            return SetVariable("transferFeeSettings", transferFeeSettings);
        }
        
        public CreateToken Nonfungible(bool nonfungible)
        {
            return SetVariable("nonfungible", nonfungible);
        }
    }
}