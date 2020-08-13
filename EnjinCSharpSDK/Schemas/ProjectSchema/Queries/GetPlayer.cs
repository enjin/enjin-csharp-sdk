using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class GetPlayer : GraphqlRequest<GetPlayer>, IPlayerFragmentArguments<GetPlayer>
    {
        protected GetPlayer() : base("enjin.sdk.project.GetPlayer")
        {
        }
        
        public GetPlayer Id(string id)
        {
            return SetVariable("id", id);
        }
    }
}