using System.Collections.Generic;
using JetBrains.Annotations;

namespace EnjinSDK.Graphql
{
    [PublicAPI]
    public class GraphqlRequest<T> : IVariableHolder<T> where T : GraphqlRequest<T>, new()
    {
        protected readonly T This;

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
        
        public Dictionary<string, object> Variables { get; }
    }
    
    [PublicAPI]
    public class GraphqlRequest : GraphqlRequest<GraphqlRequest> {}

    [PublicAPI]
    public interface IVariableHolder<out T> : IVariableHolder
    {
        T SetVariable(string key, object value);
    }

    [PublicAPI]
    public interface IVariableHolder
    {
        Dictionary<string, object> Variables { get; }
    }
}