using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class GetPlayer<T> : GraphqlRequest<T>, IPlayerFragmentArguments<T> where T : GraphqlRequest<T>, new()
    {
        protected GetPlayer() : base("enjin.sdk.project.GetPlayer")
        {
        }
        
        public T Id(string id)
        {
            return SetVariable("id", id);
        }
    }

    [PublicAPI]
    public class GetPlayer : GetPlayer<GetPlayer>
    {
    }
}