using System;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class StopPointRouteSection
    {
        [JsonProperty(PropertyName = "naptanId")]
        public string NaptanId { get; set; }

        [JsonProperty(PropertyName = "lineId")]
        public string LineId { get; set; }

        [JsonProperty(PropertyName = "mode")] public string Mode { get; set; }

        [JsonProperty(PropertyName = "validFrom")]
        public DateTimeOffset? ValidFrom { get; set; }

        [JsonProperty(PropertyName = "validTo")]
        public DateTimeOffset? ValidTo { get; set; }

        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }

        [JsonProperty(PropertyName = "routeSectionName")]
        public string RouteSectionName { get; set; }

        [JsonProperty(PropertyName = "lineString")]
        public string LineString { get; set; }

        [JsonProperty(PropertyName = "isActive")]
        public bool? IsActive { get; set; }

        [JsonProperty(PropertyName = "serviceType")]
        public string ServiceType { get; set; }

        [JsonProperty(PropertyName = "vehicleDestinationText")]
        public string VehicleDestinationText { get; set; }

        [JsonProperty(PropertyName = "destinationName")]
        public string DestinationName { get; set; }
    }
}