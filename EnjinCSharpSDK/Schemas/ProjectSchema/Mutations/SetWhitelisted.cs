using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class SetWhitelisted : GraphqlRequest<SetWhitelisted>, ITransactionRequestArguments<SetWhitelisted>
    {
        public SetWhitelisted() : base("enjin.sdk.project.SetWhitelisted")
        {
        }
        
        public SetWhitelisted TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        public SetWhitelisted AccountAddress(string accountAddress)
        {
            return SetVariable("accountAddress", accountAddress);
        }
        
        public SetWhitelisted Whitelisted(Whitelisted? whitelisted)
        {
            return SetVariable("whitelisted", whitelisted);
        }
        
        public SetWhitelisted WhitelistedAddress(string whitelistedAddress)
        {
            return SetVariable("whitelistedAddress", whitelistedAddress);
        }
        
        public SetWhitelisted On(bool? on)
        {
            return SetVariable("on", on);
        }
    }
}