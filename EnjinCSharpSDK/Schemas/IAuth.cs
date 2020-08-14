using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Models;
using Newtonsoft.Json.Linq;
using Refit;

namespace Enjin.SDK
{
    [Headers("Content-Type: application/json")]
    internal interface IAuth
    {
        [Post("/graphql/{schema}")]
        Task<ApiResponse<GraphqlResponse<AccessToken>>> Auth(string schema, [Body(BodySerializationMethod.Serialized)]
            JObject body);
    }
}