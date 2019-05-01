using System;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class MatchedRoute
    {
        [JsonProperty(PropertyName = "routeCode")]
        public string RouteCode { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }

        [JsonProperty(PropertyName = "originationName")]
        public string OriginationName { get; set; }

        [JsonProperty(PropertyName = "destinationName")]
        public string DestinationName { get; set; }

        [JsonProperty(PropertyName = "originator")]
        public string Originator { get; set; }

        [JsonProperty(PropertyName = "destination")]
        public string Destination { get; set; }

        [JsonProperty(PropertyName = "serviceType")]
        public string ServiceType { get; set; }

        [JsonProperty(PropertyName = "validTo")]
        public DateTimeOffset? ValidTo { get; set; }

        [JsonProperty(PropertyName = "validFrom")]
        public DateTimeOffset? ValidFrom { get; set; }
    }
}