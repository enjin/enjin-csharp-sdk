using System.Collections.Generic;
using JetBrains.Annotations;

namespace Enjin.SDK.Graphql
{
    /// <summary>
    /// Models the structure of a GraphQL response error.
    /// </summary>
    [PublicAPI]
    public class GraphqlError
    {
        /// <summary>
        /// Represents the error message.
        /// </summary>
        /// <value>The error message.</value>
        public string? Message { get; private set; }
        
        /// <summary>
        /// Represents the error code.
        /// </summary>
        /// <value>The error code.</value>
        public int? Code { get; private set; }
        
        /// <summary>
        /// Represents the error locations.
        /// </summary>
        /// <value>The error locations.</value>
        public List<Dictionary<string, int>>? Locations { get; private set; }
        
        /// <summary>
        /// Represents the error details.
        /// </summary>
        /// <value>The error details.</value>
        public string? Details { get; private set; }
    }
}