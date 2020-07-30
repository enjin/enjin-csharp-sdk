using System.Collections.Generic;
using JetBrains.Annotations;

namespace Enjin.SDK.Graphql
{
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
}