using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    /// <summary>
    /// Request to obtain the access token for the application.
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
        /// Sets the application ID.
        /// </summary>
        /// <param name="appId">The ID.</param>
        /// <returns>This request for chaining.</returns>
        public AuthProject Id(int? appId)
        {
            return SetVariable("id", appId);
        }

        /// <summary>
        /// Sets the secret.
        /// </summary>
        /// <param name="secret">The secret.</param>
        /// <returns>This request for chaining.</returns>
        public AuthProject Secret(string secret)
        {
            return SetVariable("secret", secret);
        }
    }
}