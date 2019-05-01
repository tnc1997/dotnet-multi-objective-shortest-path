using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class TrainLoading
    {
        [JsonProperty(PropertyName = "line")] public string Line { get; set; }

        [JsonProperty(PropertyName = "lineDirection")]
        public string LineDirection { get; set; }

        [JsonProperty(PropertyName = "platformDirection")]
        public string PlatformDirection { get; set; }

        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }

        [JsonProperty(PropertyName = "naptanTo")]
        public string NaptanTo { get; set; }

        [JsonProperty(PropertyName = "timeSlice")]
        public string TimeSlice { get; set; }

        [JsonProperty(PropertyName = "value")] public int? Value { get; set; }
    }
}