using System;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EnjinSDK.Graphql
{
    public class GraphqlResponse<T> : Exception
    {

        public T Result { get; private set; }
        public JToken Errors { get; private set; }
        
        [JsonConstructor]
        public GraphqlResponse(GraphqlData<T> data, JToken errors)
        {
            if (data != null)
                Result = data.Result;
            Errors = errors;
        }

        public bool HasErrors()
        {
            return Errors != null && Errors.Type == JTokenType.Array;
        }

        public override string ToString()
        {
            return HasErrors() ? $"{nameof(Errors)}: {Errors}" : $"{nameof(Result)}: {Result}";
        }
    }

    [UsedImplicitly]
    public class GraphqlData<T>
    {
        private const string ItemsKey = "items";
        private const string CursorKey = "cursor";
        
        public T Result { get; private set; }

        [JsonConstructor]
        public GraphqlData(JToken result)
        {
            ProcessJsonResult(result);
        }
        
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