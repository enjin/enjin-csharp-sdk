using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    /// <summary>
    /// Request to sign a message to prove wallet ownership.
    /// </summary>
    /// <seealso cref="ISharedSchema"/>
    [PublicAPI]
    public class Message : GraphqlRequest<Message>, ITransactionRequestArguments<Message>
    {
        /// <summary>
        /// Sole constructor. Sets the message to sign.
        /// </summary>
        /// <param name="message">The message.</param>
        public Message(string? message) : base("enjin.sdk.shared.Message")
        {
            SetVariable("message", message);
        }
    }
}