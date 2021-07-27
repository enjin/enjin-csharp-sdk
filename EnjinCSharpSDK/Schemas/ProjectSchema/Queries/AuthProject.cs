using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request to obtain the access token for the project.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Models.AccessToken"/>
    /// <seealso cref="IProjectSchema"/>
    [PublicAPI]
    public class AuthProject : GraphqlRequest<AuthProject>
    {
        /// <summary>
        /// Sole construction.
        /// </summary>
        public AuthProject() : base("enjin.sdk.project.AuthProject")
        {
        }

        /// <summary>
        /// Sets the project UUID.
        /// </summary>
        /// <param name="uuid">The UUID.</param>
        /// <returns>This request for chaining.</returns>
        public AuthProject Uuid(string? uuid)
        {
            return SetVariable("uuid", uuid);
        }

        /// <summary>
        /// Sets the project secret.
        /// </summary>
        /// <param name="secret">The secret.</param>
        /// <returns>This request for chaining.</returns>
        public AuthProject Secret(string? secret)
        {
            return SetVariable("secret", secret);
        }
    }
}