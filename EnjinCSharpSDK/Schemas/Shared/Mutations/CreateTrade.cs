using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class CreateTrade : GraphqlRequest<CreateTrade>, ITransactionRequestArguments<CreateTrade>
    {
        protected CreateTrade() : base("enjin.sdk.shared.CreateTrade")
        {
        }

        public CreateTrade AskingTokens(params Trade[] tokens)
        {
            return SetVariable("askingTokens", tokens);
        }

        public CreateTrade OfferingTokens(params Trade[] tokens)
        {
            return SetVariable("offeringTokens", tokens);
        }

        public CreateTrade RecipientAddress(string recipientAddress)
        {
            return SetVariable("recipientAddress", recipientAddress);
        }
    }
}