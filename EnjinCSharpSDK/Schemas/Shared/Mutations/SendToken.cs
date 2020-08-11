using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class SendToken<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected SendToken() : base("enjin.sdk.shared.SendToken")
        {
        }

        public T RecipientAddress(string recipientAddress)
        {
            return SetVariable("recipientAddress", recipientAddress);
        }

        public T TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }

        public T TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }

        public T Value(string value)
        {
            return SetVariable("value", value);
        }

        public T Data(string data)
        {
            return SetVariable("data", data);
        }
    }
    
    [PublicAPI]
    public class SendToken : SendToken<SendToken>
    {}
}