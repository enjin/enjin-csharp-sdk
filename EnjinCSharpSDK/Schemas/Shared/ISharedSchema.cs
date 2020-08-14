using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using JetBrains.Annotations;

namespace Enjin.SDK.Shared
{
    [PublicAPI]
    public interface ISharedSchema
    {
        Task<GraphqlResponse<Project>> GetProject(GetProject request);
    }
}