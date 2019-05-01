using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class MatchedStop
    {
        [JsonProperty(PropertyName = "routeId")]
        public int? RouteId { get; set; }

        [JsonProperty(PropertyName = "parentId")]
        public string ParentId { get; set; }

        [JsonProperty(PropertyName = "stationId")]
        public string StationId { get; set; }

        [JsonProperty(PropertyName = "icsId")] public string IcsId { get; set; }

        [JsonProperty(PropertyName = "topMostParentId")]
        public string TopMostParentId { get; set; }

        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }

        [JsonProperty(PropertyName = "towards")]
        public string Towards { get; set; }

        [JsonProperty(PropertyName = "modes")] public List<string> Modes { get; set; }

        [JsonProperty(PropertyName = "stopType")]
        public string StopType { get; set; }

        [JsonProperty(PropertyName = "stopLetter")]
        public string StopLetter { get; set; }

        [JsonProperty(PropertyName = "zone")] public string Zone { get; set; }

        [JsonProperty(PropertyName = "accessibilitySummary")]
        public string AccessibilitySummary { get; set; }

        [JsonProperty(PropertyName = "hasDisruption")]
        public bool? HasDisruption { get; set; }

        [JsonProperty(PropertyName = "lines")] public List<Identifier> Lines { get; set; }

        [JsonProperty(PropertyName = "status")]
        public bool? Status { get; set; }

        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        [JsonProperty(PropertyName = "url")] public string Url { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "lat")] public double? Lat { get; set; }

        [JsonProperty(PropertyName = "lon")] public double? Lon { get; set; }
    }
}