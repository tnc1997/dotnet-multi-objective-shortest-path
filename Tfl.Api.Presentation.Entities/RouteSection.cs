using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class RouteSection
    {
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        [JsonProperty(PropertyName = "lineId")]
        public string LineId { get; set; }

        [JsonProperty(PropertyName = "routeCode")]
        public string RouteCode { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "lineString")]
        public string LineString { get; set; }

        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }

        [JsonProperty(PropertyName = "originationName")]
        public string OriginationName { get; set; }

        [JsonProperty(PropertyName = "destinationName")]
        public string DestinationName { get; set; }

        [JsonProperty(PropertyName = "validTo")]
        public DateTimeOffset? ValidTo { get; set; }

        [JsonProperty(PropertyName = "validFrom")]
        public DateTimeOffset? ValidFrom { get; set; }

        [JsonProperty(PropertyName = "routeSectionNaptanEntrySequence")]
        public List<RouteSectionNaptanEntrySequence> RouteSectionNaptanEntrySequence { get; set; }
    }
}