using EnjinSDK.Graphql;
using JetBrains.Annotations;

namespace EnjinSDK.Models.App
{
    [PublicAPI]
    public class AuthApp<T> : GraphqlRequest<T> where T : GraphqlRequest<T>, new()
    {
        internal AuthApp()
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
    public class AuthApp : AuthApp<AuthApp>
    {
    }
}