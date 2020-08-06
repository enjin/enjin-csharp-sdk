using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    [PublicAPI]
    public abstract class Filter<T> where T: Filter<T>
    {
        [JsonProperty("and")]
        private List<T> _and;
        [JsonProperty("or")]
        private List<T> _or;
        
        public T And(params T[] others)
        {
            _and = others.ToList();
            return this as T;
        }
        
        public T Or(params T[] others)
        {
            _or = others.ToList();
            return this as T;
        }
    }
}