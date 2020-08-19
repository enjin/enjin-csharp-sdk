using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class Message : GraphqlRequest<Message>, ITransactionRequestArguments<Message>
    {
        public Message(string message) : base("enjin.sdk.shared.Message")
        {
            SetVariable("message", message);
        }
    }
}