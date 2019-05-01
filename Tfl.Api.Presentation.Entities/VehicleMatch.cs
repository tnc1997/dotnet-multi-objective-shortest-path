using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class VehicleMatch
    {
        [JsonProperty(PropertyName = "vrm")] public string Vrm { get; set; }

        [JsonProperty(PropertyName = "type")] public string Type { get; set; }

        [JsonProperty(PropertyName = "make")] public string Make { get; set; }

        [JsonProperty(PropertyName = "model")] public string Model { get; set; }

        [JsonProperty(PropertyName = "colour")]
        public string Colour { get; set; }

        [JsonProperty(PropertyName = "compliance")]
        public string Compliance { get; set; }
    }
}