using JetBrains.Annotations;
using Newtonsoft.Json;

namespace EnjinSDK.Graphql
{
    public class GraphqlResponse<T>
    {

        public T Result { get; private set; }
        
        [JsonConstructor]
        public GraphqlResponse(GraphqlData<T> data)
        {
            Result = data.Result;
        }

        public override string ToString()
        {
            return $"{nameof(Result)}: {Result}";
        }
    }

    [UsedImplicitly]
    public class GraphqlData<T>
    {
        public T Result { get; private set; }

        public override string ToString()
        {
            return $"{nameof(Result)}: {Result}";
        }
    }
}