using System;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class CreateToken<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        public T Name(string name)
        {
            return SetVariable("name", name);
        }
        
        public T TotalSupply(string totalSupply)
        {
            return SetVariable("totalSupply", totalSupply);
        }
        
        public T InitialReserve(string initialReserve)
        {
            return SetVariable("initialReserve", initialReserve);
        }
        
        public T SupplyModel(TokenSupplyModel supplyModel)
        {
            return SetVariable("supplyModel", supplyModel);
        }
        
        public T MeltValue(string meltValue)
        {
            return SetVariable("meltValue", meltValue);
        }
        
        public T MeltFeeRatio(int meltFeeRatio)
        {
            return SetVariable("meltFeeRatio", meltFeeRatio);
        }
        
        public T Transferable(TokenTransferable transferable)
        {
            return SetVariable("transferable", transferable);
        }
        
        public T TransferFeeSettings(TokenTransferFeeSettings transferFeeSettings)
        {
            return SetVariable("transferFeeSettings", transferFeeSettings);
        }
        
        public T Nonfungible(bool nonfungible)
        {
            return SetVariable("nonfungible", nonfungible);
        }
    }

    [PublicAPI]
    public class CreateToken : CreateToken<CreateToken>
    {
    }
}