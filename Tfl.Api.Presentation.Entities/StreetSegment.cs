using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class StreetSegment
    {
        [JsonProperty(PropertyName = "toid")] public string Toid { get; set; }

        [JsonProperty(PropertyName = "lineString")]
        public string LineString { get; set; }

        [JsonProperty(PropertyName = "sourceSystemId")]
        public long? SourceSystemId { get; set; }

        [JsonProperty(PropertyName = "sourceSystemKey")]
        public string SourceSystemKey { get; set; }
    }
}