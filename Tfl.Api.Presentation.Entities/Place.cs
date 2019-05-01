using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class Place
    {
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        [JsonProperty(PropertyName = "url")] public string Url { get; set; }

        [JsonProperty(PropertyName = "commonName")]
        public string CommonName { get; set; }

        [JsonProperty(PropertyName = "distance")]
        public double? Distance { get; set; }

        [JsonProperty(PropertyName = "placeType")]
        public string PlaceType { get; set; }

        [JsonProperty(PropertyName = "additionalProperties")]
        public List<AdditionalProperties> AdditionalProperties { get; set; }

        [JsonProperty(PropertyName = "children")]
        public List<Place> Children { get; set; }

        [JsonProperty(PropertyName = "childrenUrls")]
        public List<string> ChildrenUrls { get; set; }

        [JsonProperty(PropertyName = "lat")] public double? Lat { get; set; }

        [JsonProperty(PropertyName = "lon")] public double? Lon { get; set; }
    }
}