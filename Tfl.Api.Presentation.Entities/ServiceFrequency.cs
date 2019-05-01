using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class ServiceFrequency
    {
        [JsonProperty(PropertyName = "lowestFrequency")]
        public double? LowestFrequency { get; set; }

        [JsonProperty(PropertyName = "highestFrequency")]
        public double? HighestFrequency { get; set; }
    }
}