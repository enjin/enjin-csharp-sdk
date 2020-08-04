using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class SendEnj<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected SendEnj() : base("enjin.sdk.shared.SendEnj")
        {
        }

        public T RecipientAddress(string recipientAddress)
        {
            return SetVariable("recipientAddress", recipientAddress);
        }

        public T Value(string value)
        {
            return SetVariable("value", value);
        }
    }
    
    [PublicAPI]
    public class SendEnj : SendEnj<SendEnj>
    {}
}