using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class GeoCodeSearchMatch
    {
        [JsonProperty(PropertyName = "types")] public List<string> Types { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        [JsonProperty(PropertyName = "url")] public string Url { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "lat")] public double? Lat { get; set; }

        [JsonProperty(PropertyName = "lon")] public double? Lon { get; set; }
    }
}