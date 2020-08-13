using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class AuthProject : GraphqlRequest<AuthProject>
    {
        protected AuthProject() : base("enjin.sdk.project.AuthProject")
        {
        }

        public AuthProject Id(int appId)
        {
            return SetVariable("id", appId);
        }

        public AuthProject Secret(string secret)
        {
            return SetVariable("secret", secret);
        }
    }
}