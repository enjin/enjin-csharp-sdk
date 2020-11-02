using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Provides implementation of common filter input functionality.
    /// </summary>
    /// <typeparam name="T">The type of the implementing class.</typeparam>
    [PublicAPI]
    public abstract class Filter<T> where T: Filter<T>
    {
        [JsonProperty("and")]
        private List<T>? _and;
        [JsonProperty("or")]
        private List<T>? _or;
        
        /// <summary>
        /// Sets the filter to include other filters to intersect with.
        /// </summary>
        /// <param name="others">The other filters.</param>
        /// <returns>This filter for chaining.</returns>
        public T And(params T[]? others)
        {
            _and = others?.ToList();
            return (T) this;
        }
        
        /// <summary>
        /// Sets the filter to include other filters to union with.
        /// </summary>
        /// <param name="others">The other filters.</param>
        /// <returns>This filter for chaining.</returns>
        public T Or(params T[]? others)
        {
            _or = others?.ToList();
            return (T) this;
        }
    }
}