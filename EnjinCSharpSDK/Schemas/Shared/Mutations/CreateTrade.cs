using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class CreateTrade<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected CreateTrade() : base("enjin.sdk.shared.CreateTrade")
        {
        }

        public T AskingTokens(params Trade[] tokens)
        {
            return SetVariable("askingTokens", tokens);
        }

        public T OfferingTokens(params Trade[] tokens)
        {
            return SetVariable("offeringTokens", tokens);
        }

        public T RecipientAddress(string recipientAddress)
        {
            return SetVariable("recipientAddress", recipientAddress);
        }
    }
    
    [PublicAPI]
    public class CreateTrade : CreateTrade<CreateTrade>
    {}
}