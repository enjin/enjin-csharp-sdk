using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class SetTransferable : GraphqlRequest<SetTransferable>, ITransactionRequestArguments<SetTransferable>
    {
        protected SetTransferable() : base("enjin.sdk.project.SetTransferable")
        {
        }
        
        public SetTransferable TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        public SetTransferable TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }
        
        public SetTransferable Transferable(TokenTransferable transferable)
        {
            return SetVariable("transferable", transferable);
        }
    }
}