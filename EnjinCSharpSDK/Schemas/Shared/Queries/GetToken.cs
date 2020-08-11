using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class GetToken<T> : GraphqlRequest<T>, ITokenFragmentArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected GetToken() : base("enjin.sdk.shared.GetToken")
        {
        }

        public T Id(string id)
        {
            return SetVariable("id", id);
        }
    }
    
    [PublicAPI]
    public class GetToken : GetToken<GetToken>
    {}
}