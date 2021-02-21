using JetBrains.Annotations;
using Newtonsoft.Json;

namespace Enjin.SDK.Models
{
    /// <summary>
    /// Models sorting input for assets.
    /// </summary>
    [PublicAPI]
    public class AssetSort
    {
        [JsonProperty("field")]
        private AssetField? _field;
        [JsonProperty("direction")]
        private SortDirection? _direction;

        /// <summary>
        /// Sets the field to sort by.
        /// </summary>
        /// <param name="field">The field.</param>
        /// <returns>This input for chaining.</returns>
        public AssetSort Field(AssetField? field)
        {
            _field = field;
            return this;
        }

        /// <summary>
        /// Sets the direction to sort by.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>This input for chaining.</returns>
        public AssetSort Direction(SortDirection? direction)
        {
            _direction = direction;
            return this;
        }
    }
}