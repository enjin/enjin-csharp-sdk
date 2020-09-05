using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Enjin.SDK.Graphql
{
    /// <summary>
    /// Models the body of a GraphQL response.
    /// </summary>
    /// <typeparam name="T">The model of the data field.</typeparam>
    public class GraphqlResponse<T> : Exception
    {
        /// <summary>
        /// Represents the result of this response.
        /// </summary>
        /// <value>The result.</value>
        public T Result { get; private set; }
        
        /// <summary>
        /// Represents the errors of this response if any exist.
        /// </summary>
        /// <value>The errors.</value>
        public JToken Errors { get; private set; }
        
        /// <summary>
        /// Sole constructor.
        /// </summary>
        /// <param name="data">The data container.</param>
        /// <param name="errors">The serialized errors.</param>
        [JsonConstructor]
        public GraphqlResponse(GraphqlData<T> data, JToken errors)
        {
            if (data != null)
                Result = data.Result;
            Errors = errors;
        }

        /// <summary>
        /// Determines if the response has errors on not.
        /// </summary>
        /// <returns>Whether the response has errors.</returns>
        public bool HasErrors()
        {
            return Errors != null && Errors.Type == JTokenType.Array;
        }

        /// <summary>
        /// Returns the string representative of this response. Will provide either the result or the errors if errors
        /// are present.
        /// </summary>
        /// <returns>The string representing the response.</returns>
        public override string ToString()
        {
            return HasErrors() ? $"{nameof(Errors)}: {Errors}" : $"{nameof(Result)}: {Result}";
        }
    }

    /// <summary>
    /// Container for GraphQL data.
    /// </summary>
    /// <typeparam name="T">The model type.</typeparam>
    [UsedImplicitly]
    public class GraphqlData<T>
    {
        private const string ItemsKey = "items";
        private const string CursorKey = "cursor";
        
        /// <summary>
        /// Represents the deserialized GraphQL result.
        /// </summary>
        /// <value>The result.</value>
        public T Result { get; private set; }

        /// <summary>
        /// Sole constructor.
        /// </summary>
        /// <param name="result">The serialized result.</param>
        [JsonConstructor]
        public GraphqlData(JToken result)
        {
            ProcessJsonResult(result);
        }
        
        /// <summary>
        /// Returns a string that represents the result in the data.
        /// </summary>
        /// <returns>The string representing the result.</returns>
        public override string ToString()
        {
            return $"{nameof(Result)}: {Result}";
        }

        private void ProcessJsonResult(JToken result)
        {
            if (result.Type == JTokenType.Object)
                ProcessResultObject((JObject) result);
            else
            {
                Result = result.ToObject<T>();
            }
        }

        private void ProcessResultObject(JObject result)
        {
            var isPaginated = result.ContainsKey(ItemsKey);
            if (isPaginated)
            {
                var items = result[ItemsKey];
                if (items != null && items.Type == JTokenType.Array)
                {
                    Result = items.ToObject<T>();
                }
                
                if (result.ContainsKey(CursorKey))
                    return; // TODO: Create Cursor type and deserialize.
            }
            else
            {
                Result = result.ToObject<T>();
            }
        }
    }
}