using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class TimeAdjustment
    {
        [JsonProperty(PropertyName = "date")] public string Date { get; set; }

        [JsonProperty(PropertyName = "time")] public string Time { get; set; }

        [JsonProperty(PropertyName = "timeIs")]
        public string TimeIs { get; set; }

        [JsonProperty(PropertyName = "uri")] public string Uri { get; set; }
    }
}