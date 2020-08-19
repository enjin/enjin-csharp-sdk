using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class SendEnj : GraphqlRequest<SendEnj>, ITransactionRequestArguments<SendEnj>
    {
        public SendEnj() : base("enjin.sdk.shared.SendEnj")
        {
        }

        public SendEnj RecipientAddress(string recipientAddress)
        {
            return SetVariable("recipientAddress", recipientAddress);
        }

        public SendEnj Value(string value)
        {
            return SetVariable("value", value);
        }
    }
}