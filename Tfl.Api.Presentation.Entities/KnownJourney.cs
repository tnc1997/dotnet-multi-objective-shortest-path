using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class KnownJourney
    {
        [JsonProperty(PropertyName = "hour")] public string Hour { get; set; }

        [JsonProperty(PropertyName = "minute")]
        public string Minute { get; set; }

        [JsonProperty(PropertyName = "intervalId")]
        public int? IntervalId { get; set; }
    }
}