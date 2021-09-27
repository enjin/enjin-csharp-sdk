/* Copyright 2021 Enjin Pte. Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Threading.Tasks;
using Enjin.SDK.Graphql;
using Enjin.SDK.Serialization;
using Enjin.SDK.Utils;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Refit;

namespace Enjin.SDK
{
    /// <summary>
    /// Base class for schema with functionality to send GraphQL requests to the platform and process the responses.
    /// </summary>
    [PublicAPI]
    public class BaseSchema
    {
        public LoggerProvider LoggerProvider { get; private set; }

        protected readonly TrustedPlatformMiddleware Middleware;
        protected readonly string Schema;

        /// <summary>
        /// Sole constructor.
        /// </summary>
        /// <param name="middleware">The middleware.</param>
        /// <param name="schema">The schema.</param>
        /// <param name="loggerProvider">The logger provider.</param>
        protected BaseSchema(TrustedPlatformMiddleware middleware, string schema, LoggerProvider loggerProvider)
        {
            Middleware = middleware;
            Schema = schema;
            LoggerProvider = loggerProvider;
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
                {"query", Middleware.Registry.GetOperationForName(request.Namespace)?.CompiledContents},
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
        protected Task<GraphqlResponse<T>> SendRequest<T>(Task<ApiResponse<GraphqlResponse<T>>> taskIn)
        {
            return taskIn.ContinueWith(task =>
            {
                try
                {
                    var result = task.Result;
                    return result.IsSuccessStatusCode
                        ? result.Content
                        : JsonConvert.DeserializeObject<GraphqlResponse<T>>(result.Error.Content);
                }
                catch (Exception e)
                {
                    LoggerProvider.Log(LogLevel.SEVERE,
                                       "An error occured while processing a request or a response.",
                                       e);
                    throw;
                }
            });
        }
    }
}