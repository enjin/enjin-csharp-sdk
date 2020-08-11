using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Refit;

namespace Enjin.SDK
{
    public class BaseSchema
    {
        protected readonly TrustedPlatformMiddleware Middleware;

        protected BaseSchema(TrustedPlatformMiddleware middleware)
        {
            Middleware = middleware;
        }

        protected JObject CreateRequestBody(IGraphqlRequest request)
        {
            var obj = new JObject
            {
                {"query", Middleware.Registry.GetOperationForName(request.Namespace).CompiledContents},
                {"variables", JToken.FromObject(request.Variables)}
            };
            return obj;
        }

        protected T CreateService<T>()
        {
            return RestService.For<T>(Middleware.HttpClient, CreateRefitSettings());
        }

        private static RefitSettings CreateRefitSettings()
        {
            return new RefitSettings()
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(CreateSerializerSettings())
            };
        }

        private static JsonSerializerSettings CreateSerializerSettings()
        {
            return new JsonSerializerSettings()
            {
                ContractResolver = new PrivateSetterContractResolver(),
                Converters = {new StringEnumConverter()}
            };
        }

        protected static Task<GraphqlResponse<T>> SendRequest<T>(Task<ApiResponse<GraphqlResponse<T>>> taskIn)
        {
            return taskIn.ContinueWith(task =>
            {
                var result = task.Result;
                return result.IsSuccessStatusCode
                    ? result.Content
                    : JsonConvert.DeserializeObject<GraphqlResponse<T>>(result.Error.Content);
            });
        }
    }
}