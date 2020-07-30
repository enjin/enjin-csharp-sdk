using System.Collections.Generic;
using JetBrains.Annotations;

namespace Enjin.SDK.Graphql
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
}