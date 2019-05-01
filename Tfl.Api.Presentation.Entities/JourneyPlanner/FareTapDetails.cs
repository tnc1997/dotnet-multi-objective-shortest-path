using System;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class FareTapDetails
    {
        [JsonProperty(PropertyName = "modeType")]
        public string ModeType { get; set; }

        [JsonProperty(PropertyName = "validationType")]
        public string ValidationType { get; set; }

        [JsonProperty(PropertyName = "hostDeviceType")]
        public string HostDeviceType { get; set; }

        [JsonProperty(PropertyName = "busRouteId")]
        public string BusRouteId { get; set; }

        [JsonProperty(PropertyName = "nationalLocationCode")]
        public int? NationalLocationCode { get; set; }

        [JsonProperty(PropertyName = "tapTimestamp")]
        public DateTimeOffset? TapTimestamp { get; set; }
    }
}