using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class Message<T> : GraphqlRequest<T>, ITransactionRequestArguments<T> where T : GraphqlRequest<T>
    {
        protected Message(string message) : base("enjin.sdk.shared.Message")
        {
            SetVariable("message", message);
        }
    }
    
    [PublicAPI]
    public class Message : Message<Message>
    {
        protected Message(string message) : base(message)
        {
        }
    }
}