namespace EnjinSDK.Graphql
{
    public class GraphqlResponse<T>
    {
        public GraphqlData<T> data { get; private set; }

        public override string ToString()
        {
            return $"{nameof(data)}: {data}";
        }
    }

    public class GraphqlData<T>
    {
        public T result { get; private set; }

        public override string ToString()
        {
            return $"{nameof(result)}: {result}";
        }
    }
}