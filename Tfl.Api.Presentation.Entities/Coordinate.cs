using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class Coordinate
    {
        [JsonProperty(PropertyName = "longitude")]
        public double? Longitude { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public double? Latitude { get; set; }

        [JsonProperty(PropertyName = "easting")]
        public double? Easting { get; set; }

        [JsonProperty(PropertyName = "northing")]
        public double? Northing { get; set; }

        [JsonProperty(PropertyName = "xCoord")]
        public int? XCoord { get; set; }

        [JsonProperty(PropertyName = "yCoord")]
        public int? YCoord { get; set; }
    }
}