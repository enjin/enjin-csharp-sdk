using Enjin.SDK.Graphql;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public interface ISharedSchema
    {
        GraphqlResponse<Project> GetProject(GetProject query);
    }
}