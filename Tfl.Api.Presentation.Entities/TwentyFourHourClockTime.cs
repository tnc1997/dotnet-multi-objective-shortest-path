using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class TwentyFourHourClockTime
    {
        [JsonProperty(PropertyName = "hour")] public string Hour { get; set; }

        [JsonProperty(PropertyName = "minute")]
        public string Minute { get; set; }
    }
}