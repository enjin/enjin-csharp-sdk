/* Copyright 2021 Enjin Pte. Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

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