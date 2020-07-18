using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Refit;

namespace Enjin.SDK
{
    public class BaseService
    {
        protected readonly TrustedPlatformMiddleware Middleware;

        protected BaseService(TrustedPlatformMiddleware middleware)
        {
            Middleware = middleware;
        }

        protected JObject CreateRequestBody(IVariableHolder holder, string template)
        {
            var obj = new JObject
            {
                {"query", Middleware.Registry.GetOperationForName(template).CompiledContents},
                {"variables", JToken.FromObject(holder.Variables())}
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

        protected static async Task<GraphqlResponse<T>> SendRequest<T>(Task<ApiResponse<GraphqlResponse<T>>> taskIn)
        {
            return await taskIn.ContinueWith(task =>
            {
                var result = task.Result;
                return result.IsSuccessStatusCode
                    ? result.Content
                    : JsonConvert.DeserializeObject<GraphqlResponse<T>>(result.Error.Content);
            });
        }
    }
}