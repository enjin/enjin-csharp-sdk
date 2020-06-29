using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace EnjinSDK.Graphql
{
    public class GraphqlRequest<T> : IVariableHolder<T> where T : GraphqlRequest<T>, new()
    {
        protected readonly T This;

        protected GraphqlRequest(Dictionary<string, object> variables)
        {
            Variables = variables;
            This = (T) this;
        }

        public GraphqlRequest() : this(new Dictionary<string, object>()) {}

        public T SetVariable(string key, object value)
        {
            Variables.Add(key, value);
            return This;
        }
        
        public Dictionary<string, object> Variables { get; }
    }
    
    public class GraphqlRequest : GraphqlRequest<GraphqlRequest> {}

    public interface IVariableHolder<T> : IVariableHolder
    {
        T SetVariable(string key, object value);
    }

    public interface IVariableHolder
    {
        Dictionary<string, object> Variables { get; }
    }
}