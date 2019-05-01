using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class DbGeographyWellKnownValue
    {
        [JsonProperty(PropertyName = "coordinateSystemId")]
        public int? CoordinateSystemId { get; set; }

        [JsonProperty(PropertyName = "wellKnownText")]
        public string WellKnownText { get; set; }

        [JsonProperty(PropertyName = "wellKnownBinary")]
        public byte[] WellKnownBinary { get; set; }
    }
}