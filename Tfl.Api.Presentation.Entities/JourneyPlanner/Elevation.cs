using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class Elevation
    {
        [JsonProperty(PropertyName = "distance")]
        public int? Distance { get; set; }

        [JsonProperty(PropertyName = "startLat")]
        public double? StartLat { get; set; }

        [JsonProperty(PropertyName = "startLon")]
        public double? StartLon { get; set; }

        [JsonProperty(PropertyName = "endLat")]
        public double? EndLat { get; set; }

        [JsonProperty(PropertyName = "endLon")]
        public double? EndLon { get; set; }

        [JsonProperty(PropertyName = "heightFromPreviousPoint")]
        public int? HeightFromPreviousPoint { get; set; }

        [JsonProperty(PropertyName = "gradient")]
        public double? Gradient { get; set; }
    }
}