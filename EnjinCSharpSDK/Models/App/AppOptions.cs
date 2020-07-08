using JetBrains.Annotations;
using Newtonsoft.Json;

namespace EnjinSDK.Models.App
{
    [PublicAPI]
    public class AppOptions
    {
        [JsonProperty("tokenProofEnabled")]
        public bool TokenProofEnabled { get; set; }
        
        [JsonProperty("tokenProofUrl")]
        public string TokenProofUrl { get; set; }
        
        [JsonProperty("weakChallengeDefault")]
        public bool WeakChallengeDefault { get; set; }
    }
}