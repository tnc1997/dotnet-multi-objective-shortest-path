using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class GeoPointBox
    {
        [JsonProperty(PropertyName = "swLat")] public double SwLat { get; set; }

        [JsonProperty(PropertyName = "swLon")] public double SwLon { get; set; }

        [JsonProperty(PropertyName = "neLat")] public double NeLat { get; set; }

        [JsonProperty(PropertyName = "neLon")] public double NeLon { get; set; }
    }
}