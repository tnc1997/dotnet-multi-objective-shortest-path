using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class Obstacle
    {
        [JsonProperty(PropertyName = "type")] public string Type { get; set; }

        [JsonProperty(PropertyName = "incline")]
        public string Incline { get; set; }

        [JsonProperty(PropertyName = "stopId")]
        public int? StopId { get; set; }

        [JsonProperty(PropertyName = "position")]
        public string Position { get; set; }
    }
}