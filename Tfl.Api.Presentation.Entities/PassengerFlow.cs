using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class PassengerFlow
    {
        [JsonProperty(PropertyName = "timeSlice")]
        public string TimeSlice { get; set; }

        [JsonProperty(PropertyName = "value")] public int? Value { get; set; }
    }
}