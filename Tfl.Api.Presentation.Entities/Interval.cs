using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class Interval
    {
        [JsonProperty(PropertyName = "stopId")]
        public string StopId { get; set; }

        [JsonProperty(PropertyName = "timeToArrival")]
        public double? TimeToArrival { get; set; }
    }
}