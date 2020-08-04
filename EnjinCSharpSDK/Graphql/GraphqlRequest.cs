using System.Collections.Generic;
using JetBrains.Annotations;

namespace Enjin.SDK.Graphql
{
    [PublicAPI]
    public class GraphqlRequest<T> : IVariableHolder<T>, IGraphqlRequest where T : GraphqlRequest<T>
    {
        protected readonly T This;
        public Dictionary<string, object> Variables { get; }
        public string Namespace { get; }

        protected GraphqlRequest(Dictionary<string, object> variables, string templateKey)
        {
            Variables = variables;
            This = (T) this;
            Namespace = templateKey;
        }

        protected GraphqlRequest(string templateKey) : this(new Dictionary<string, object>(), templateKey) {}

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
    public interface IGraphqlRequest
    {
        Dictionary<string, object> Variables { get; }
        
        string Namespace { get; }
    }
}