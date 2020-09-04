using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Refit;

namespace Enjin.SDK
{
    /// <summary>
    /// Base class for schema with functionality to send GraphQL requests to the platform and process the responses.
    /// </summary>
    public class BaseSchema
    {
        protected readonly TrustedPlatformMiddleware Middleware;
        protected readonly string Schema;

        /// <summary>
        /// Sole constructor.
        /// </summary>
        /// <param name="middleware">The middleware.</param>
        /// <param name="schema">The schema.</param>
        protected BaseSchema(TrustedPlatformMiddleware middleware, string schema)
        {
            Middleware = middleware;
            Schema = schema;
        }

        /// <summary>
        /// Creates the serialized request body to be sent to the platform.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The serialized object.</returns>
        protected JObject CreateRequestBody(IGraphqlRequest request)
        {
            var obj = new JObject
            {
                {"query", Middleware.Registry.GetOperationForName(request.Namespace).CompiledContents},
                {"variables", JToken.FromObject(request.Variables)}
            };
            return obj;
        }

        /// <summary>
        /// Creates a rest service for the type.
        /// </summary>
        /// <typeparam name="T">The type to create the service for.</typeparam>
        /// <returns>The type as a rest service.</returns>
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

        /// <summary>
        /// Sends a request asynchronously.
        /// </summary>
        /// <param name="taskIn">The task that will start the request.</param>
        /// <typeparam name="T">The type of the response.</typeparam>
        /// <returns>The task that will contain the response.</returns>
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