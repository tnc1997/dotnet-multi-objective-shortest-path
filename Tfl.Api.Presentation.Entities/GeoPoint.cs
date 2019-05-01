using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class GeoPoint
    {
        [JsonProperty(PropertyName = "lat")] public double Lat { get; set; }

        [JsonProperty(PropertyName = "lon")] public double Lon { get; set; }
    }
}