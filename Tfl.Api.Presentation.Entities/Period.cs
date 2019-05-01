using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class Period
    {
        [JsonProperty(PropertyName = "type")] public string Type { get; set; }

        [JsonProperty(PropertyName = "fromTime")]
        public TwentyFourHourClockTime FromTime { get; set; }

        [JsonProperty(PropertyName = "toTime")]
        public TwentyFourHourClockTime ToTime { get; set; }

        [JsonProperty(PropertyName = "frequency")]
        public ServiceFrequency Frequency { get; set; }
    }
}