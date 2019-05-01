using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class PlacePolygon
    {
        [JsonProperty(PropertyName = "geoPoints")]
        public List<GeoPoint> GeoPoints { get; set; }

        [JsonProperty(PropertyName = "commonName")]
        public string CommonName { get; set; }
    }
}