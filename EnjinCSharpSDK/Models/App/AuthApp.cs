using EnjinSDK.Graphql;
using JetBrains.Annotations;

namespace EnjinSDK.Models.App
{
    [PublicAPI]
    public class AuthApp<T> : GraphqlRequest<T> where T : GraphqlRequest<T>, new()
    {
        public T Id(int appId)
        {
            SetVariable("id", appId);
            return This;
        }

        public T Secret(string secret)
        {
            SetVariable("secret", secret);
            return This;
        }
    }
    
    public class AuthApp : AuthApp<AuthApp> {}
}