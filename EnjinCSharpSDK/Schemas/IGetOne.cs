using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Newtonsoft.Json.Linq;
using Refit;

namespace Enjin.SDK
{
    [Headers("Content-Type: application/json")]
    internal interface IGetOne<T>
    {
        [Post("/graphql/{schema}")]
        Task<ApiResponse<GraphqlResponse<T>>> GetOne(string schema, [Body(BodySerializationMethod.Serialized)]
            JObject body);
    }
}