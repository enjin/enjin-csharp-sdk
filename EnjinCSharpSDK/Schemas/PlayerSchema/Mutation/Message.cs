using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.PlayerSchema
{
    /// <summary>
    /// Request to sign a message to prove wallet ownership.
    /// </summary>
    /// <seealso cref="IPlayerSchema"/>
    [PublicAPI]
    public class Message : GraphqlRequest<Message>, ITransactionFragmentArguments<Message>
    {
        /// <summary>
        /// Sole constructor. Sets the message to sign.
        /// </summary>
        /// <param name="message">The message.</param>
        public Message(string? message) : base("enjin.sdk.player.Message")
        {
            SetVariable("message", message);
        }
    }
}