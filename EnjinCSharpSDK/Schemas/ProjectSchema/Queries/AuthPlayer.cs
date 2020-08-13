using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class AuthPlayer : GraphqlRequest<AuthPlayer>
    {
        protected AuthPlayer() : base("enjin.sdk.project.AuthPlayer")
        {
        }
        
        public AuthPlayer Id(string id)
        {
            return SetVariable("id", id);
        }
    }
}