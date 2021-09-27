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

using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Enjin.SDK.Graphql
{
    /// <summary>
    /// Facilitates setting variables to be used in a GraphQL request.
    /// </summary>
    /// <typeparam name="T">The type of the implementing class.</typeparam>
    [PublicAPI]
    public class GraphqlRequest<T> : IVariableHolder<T>, IGraphqlRequest where T : GraphqlRequest<T>
    {
        /// <inheritdoc/>
        public Dictionary<string, object> Variables { get; }
        
        /// <inheritdoc/>
        public string Namespace { get; }

        /// <summary>
        /// Constructs a request with the passed variable mapping and namespace (template key).
        /// </summary>
        /// <param name="variables">The variable mapping.</param>
        /// <param name="templateKey">The namespace.</param>
        protected GraphqlRequest(Dictionary<string, object> variables, string templateKey)
        {
            Variables = variables;
            Namespace = templateKey;
        }

        /// <summary>
        /// Constructs a request with the passed namespace (template key) and an empty variable mapping.
        /// </summary>
        /// <param name="templateKey">The namespace.</param>
        protected GraphqlRequest(string templateKey) : this(new Dictionary<string, object>(), templateKey) {}

        /// <inheritdoc/>
        public T SetVariable(string key, object? value)
        {
            if (value == null)
                Variables.Remove(key);
            else
                Variables.Add(key, value);
            
            return (T) this;
        }

        /// <inheritdoc/>
        public bool IsSet(string key)
        {
            return Variables.ContainsKey(key);
        }

        Dictionary<string, object> IVariableHolder.Variables()
        {
            return Variables;
        }
    }
    
    /// <summary>
    /// Interface for GraphQL requests.
    /// </summary>
    [PublicAPI]
    public interface IGraphqlRequest
    {
        /// <summary>
        /// Represents the variables of the request that have been set.
        /// </summary>
        /// <value>The variable mapping.</value>
        Dictionary<string, object> Variables { get; }
        
        /// <summary>
        /// Represents the namespace of the request.
        /// </summary>
        /// <value>The namespace.</value>
        string Namespace { get; }
    }
}