using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request to sign a message to prove wallet ownership.
    /// </summary>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class Message : GraphqlRequest<Message>, IProjectTransactionRequestArguments<Message>
    {
        /// <summary>
        /// Sole constructor. Sets the message to sign.
        /// </summary>
        /// <param name="message">The message.</param>
        public Message(string? message) : base("enjin.sdk.project.Message")
        {
            SetVariable("message", message);
        }
    }
}