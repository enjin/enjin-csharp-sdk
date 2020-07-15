using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class AuthPlayer<T> : GraphqlRequest<T> where T : GraphqlRequest<T>, new()
    {
        internal AuthPlayer()
        {
        }

        public T Id(string id)
        {
            return SetVariable("id", id);
        }
    }

    [PublicAPI]
    public class AuthPlayer : AuthPlayer<AuthPlayer>
    {
    }
}