using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class GetTokens : GraphqlRequest<GetTokens>, ITokenFragmentArguments<GetTokens>, IPaginationArguments<GetTokens>
    {
        public GetTokens() : base("enjin.sdk.shared.GetTokens")
        {
        }

        public GetTokens Filter(TokenFilter filter)
        {
            return SetVariable("filter", filter);
        }

        public GetTokens Sort(TokenSort sort)
        {
            return SetVariable("sort", sort);
        }
    }
}