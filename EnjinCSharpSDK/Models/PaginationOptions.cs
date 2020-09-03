using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a pagination input for pagination requests.
    /// </summary>
    /// <seealso cref="Enjin.SDK.Shared.PaginationArguments"/>
    [PublicAPI]
    public class PaginationOptions
    {
        /// <summary>
        /// Represents the page number to start at for the pagination.
        /// </summary>
        /// <value>The page to start at.</value>
        [JsonProperty("page")]
        public int? Page { get; set; }
        
        /// <summary>
        /// Represents the number of results per page for the pagination.
        /// </summary>
        /// <value>The number of items per page.</value>
        [JsonProperty("limit")]
        public int? Limit { get; set; }
    }
}