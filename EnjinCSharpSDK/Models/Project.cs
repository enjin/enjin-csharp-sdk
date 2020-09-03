using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models a application on the platform.
    /// </summary>
    [PublicAPI]
    public class Project
    {
        /// <summary>
        /// Represents the ID of this application.
        /// </summary>
        /// <value>The ID.</value>
        [JsonProperty("id")]
        public int Id { get; private set; }
        
        /// <summary>
        /// Represents the name of this application.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Represents the description text for this application.
        /// </summary>
        /// <value>The description.</value>
        [JsonProperty("description")]
        public string Description { get; private set; }
        
        /// <summary>
        /// Represents the URL for the image of this application.
        /// </summary>
        /// <value>The URL.</value>
        [JsonProperty("image")]
        public string Image { get; private set; }

        /// <summary>
        /// Represents the datetime when this application was created.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("createdAt")]
        public string CreatedAt { get; private set; }
        
        /// <summary>
        /// Represents the datetime when this application was last updated.
        /// </summary>
        /// <value>The datetime.</value>
        /// <remarks>
        /// The datetime is formatted using the ISO 8601 date format.
        /// </remarks>
        [JsonProperty("updatedAt")]
        public string UpdatedAt { get; private set; }
    }
}