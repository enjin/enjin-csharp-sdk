using System.Collections.Generic;
using JetBrains.Annotations;

namespace Enjin.SDK.Graphql
{
    /// <summary>
    /// Interface for GraphQL requests to set variables within them.
    /// </summary>
    /// <typeparam name="T">The implementing type of the interface.</typeparam>
    [PublicAPI]
    public interface IVariableHolder<out T> : IVariableHolder
    {
        /// <summary>
        /// Sets a variable with the specified key and value.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>This object for chaining.</returns>
        T SetVariable(string key, object? value);
        
        /// <summary>
        /// Determines if a variable exists for the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Whether the variable exists.</returns>
        bool IsSet(string key);
        
    }
    
    /// <summary>
    /// Interface for holding variables.
    /// </summary>
    [PublicAPI]
    public interface IVariableHolder
    {
        /// <summary>
        /// Gets the variables this object holds.
        /// </summary>
        /// <returns>The variables.</returns>
        Dictionary<string, object> Variables();
    }
}