using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class GetTokens<T>: GraphqlRequest<T>, ITokenFragmentArguments<T>, IPaginationArguments<T>
        where T : GraphqlRequest<T>, new()
    {
        protected GetTokens() : base("enjin.sdk.shared.GetTokens")
        {
        }

        public T Filter(TokenFilter filter)
        {
            return SetVariable("filter", filter);
        }

        public T Sort(TokenSort sort)
        {
            return SetVariable("sort", sort);
        }
    }

    [PublicAPI]
    public class GetTokens : GetTokens<GetTokens>
    {
    }
}