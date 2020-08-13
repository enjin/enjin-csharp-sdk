using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public class GetToken : GraphqlRequest<GetToken>, ITokenFragmentArguments<GetToken>
    {
        protected GetToken() : base("enjin.sdk.shared.GetToken")
        {
        }

        public GetToken Id(string id)
        {
            return SetVariable("id", id);
        }
    }
}