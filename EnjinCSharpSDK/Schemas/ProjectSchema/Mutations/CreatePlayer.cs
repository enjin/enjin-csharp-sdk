using Enjin.SDK.Graphql;
using Enjin.SDK.Shared;
using JetBrains.Annotations;

namespace Enjin.SDK.ProjectSchema
{
    [PublicAPI]
    public class CreatePlayer : GraphqlRequest<CreatePlayer>
    {
        public CreatePlayer() : base("enjin.sdk.project.CreatePlayer")
        {
        }
        
        public CreatePlayer Id(string id)
        {
            return SetVariable("id", id);
        }
    }
}