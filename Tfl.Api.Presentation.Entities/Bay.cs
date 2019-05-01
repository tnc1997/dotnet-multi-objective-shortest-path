using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class Bay
    {
        [JsonProperty(PropertyName = "bayType")]
        public string BayType { get; set; }

        [JsonProperty(PropertyName = "bayCount")]
        public int? BayCount { get; set; }

        [JsonProperty(PropertyName = "free")] public int? Free { get; set; }

        [JsonProperty(PropertyName = "occupied")]
        public int? Occupied { get; set; }
    }
}