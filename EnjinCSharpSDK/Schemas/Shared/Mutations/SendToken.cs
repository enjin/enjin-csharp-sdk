using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class SendToken : GraphqlRequest<SendToken>, ITransactionRequestArguments<SendToken>
    {
        protected SendToken() : base("enjin.sdk.shared.SendToken")
        {
        }

        public SendToken RecipientAddress(string recipientAddress)
        {
            return SetVariable("recipientAddress", recipientAddress);
        }

        public SendToken TokenId(string tokenId)
        {
            return SetVariable("tokenId", tokenId);
        }

        public SendToken TokenIndex(string tokenIndex)
        {
            return SetVariable("tokenIndex", tokenIndex);
        }

        public SendToken Value(string value)
        {
            return SetVariable("value", value);
        }

        public SendToken Data(string data)
        {
            return SetVariable("data", data);
        }
    }
}