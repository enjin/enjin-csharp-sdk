using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class SetWhitelisted<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        public T TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }
        
        public T AccountAddress(string accountAddress)
        {
            return SetVariable("accountAddress", accountAddress);
        }
        
        public T Whitelisted(Whitelisted whitelisted)
        {
            return SetVariable("whitelisted", whitelisted);
        }
        
        public T WhitelistedAddress(string whitelistedAddress)
        {
            return SetVariable("whitelistedAddress", whitelistedAddress);
        }
        
        public T On(bool on)
        {
            return SetVariable("on", on);
        }
    }

    [PublicAPI]
    public class SetWhitelisted : SetWhitelisted<SetWhitelisted>
    {
    }

    [PublicAPI]
    public enum Whitelisted
    {
        NONE,
        SEND_AND_RECEIVE,
        SEND,
        RECEIVE,
        NO_FEES,
        ADDRESS
    }
}