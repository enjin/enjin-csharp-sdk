using System.Collections.Generic;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace EnjinSDK.Graphql
{
    [PublicAPI]
    public class GraphqlRequest<T> : IVariableHolder<T> where T : GraphqlRequest<T>, new()
    {
        protected readonly T This;
        public Dictionary<string, object> Variables { get; }

        protected GraphqlRequest(Dictionary<string, object> variables)
        {
            Variables = variables;
            This = (T) this;
        }

        protected GraphqlRequest() : this(new Dictionary<string, object>()) {}

        public T SetVariable(string key, object value)
        {
            Variables.Add(key, value);
            return This;
        }

        public bool IsSet(string key)
        {
            return Variables.ContainsKey(key);
        }

        Dictionary<string, object> IVariableHolder.Variables()
        {
            return Variables;
        }
    }
    
    [PublicAPI]
    public class GraphqlRequest : GraphqlRequest<GraphqlRequest> {}

    [PublicAPI]
    public interface IVariableHolder<out T> : IVariableHolder
    {
        T SetVariable(string key, object value);
        
        bool IsSet(string key);
        
    }

    [PublicAPI]
    public interface IVariableHolder
    {
        Dictionary<string, object> Variables();
    }
    
    [PublicAPI]
    public class PaginationRequest<T> : GraphqlRequest<T> where T : PaginationRequest<T>, new()
    {
        public T Paginate(PaginationOptions pagination)
        {
            return SetVariable("pagination", pagination);
        }

        public T Paginate(int page, int limit = 10)
        {
            return Paginate(new PaginationOptions()
            {
                Page = page,
                Limit = limit
            });
        }
    }
    
    [PublicAPI]
    public class PaginationOptions
    {
        [JsonProperty("page")]
        public int Page { get; set; }
        
        [JsonProperty("limit")]
        public int Limit { get; set; }
    }
}