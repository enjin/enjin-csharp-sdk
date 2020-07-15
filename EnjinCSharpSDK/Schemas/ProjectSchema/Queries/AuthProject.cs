using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class AuthProject<T> : GraphqlRequest<T> where T : GraphqlRequest<T>, new()
    {
        internal AuthProject()
        {
        }

        public T Id(int appId)
        {
            return SetVariable("id", appId);
        }

        public T Secret(string secret)
        {
            return SetVariable("secret", secret);
        }
    }

    [PublicAPI]
    public class AuthProject : AuthProject<AuthProject>
    {
    }
}