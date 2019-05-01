using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class Mode
    {
        [JsonProperty(PropertyName = "isTflService")]
        public bool? IsTflService { get; set; }

        [JsonProperty(PropertyName = "isFarePaying")]
        public bool? IsFarePaying { get; set; }

        [JsonProperty(PropertyName = "isScheduledService")]
        public bool? IsScheduledService { get; set; }

        [JsonProperty(PropertyName = "modeName")]
        public string ModeName { get; set; }
    }
}