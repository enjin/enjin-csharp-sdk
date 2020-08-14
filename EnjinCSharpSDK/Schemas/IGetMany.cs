using System.Collections.Generic;
using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Newtonsoft.Json.Linq;
using Refit;

namespace Enjin.SDK
{
    [Headers("Content-Type: application/json")]
    internal interface IGetMany<T>
    {
        [Post("/graphql/{schema}")]
        Task<ApiResponse<GraphqlResponse<List<T>>>> GetMany(string schema, [Body(BodySerializationMethod.Serialized)]
            JObject body);
    }
}