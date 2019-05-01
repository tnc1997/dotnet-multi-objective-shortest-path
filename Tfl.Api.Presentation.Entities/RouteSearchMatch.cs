using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class RouteSearchMatch
    {
        [JsonProperty(PropertyName = "lineId")]
        public string LineId { get; set; }

        [JsonProperty(PropertyName = "mode")] public string Mode { get; set; }

        [JsonProperty(PropertyName = "lineName")]
        public string LineName { get; set; }

        [JsonProperty(PropertyName = "lineRouteSection")]
        public List<LineRouteSection> LineRouteSection { get; set; }

        [JsonProperty(PropertyName = "matchedRouteSections")]
        public List<MatchedRouteSections> MatchedRouteSections { get; set; }

        [JsonProperty(PropertyName = "matchedStops")]
        public List<MatchedStop> MatchedStops { get; set; }

        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        [JsonProperty(PropertyName = "url")] public string Url { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "lat")] public double? Lat { get; set; }

        [JsonProperty(PropertyName = "lon")] public double? Lon { get; set; }
    }
}