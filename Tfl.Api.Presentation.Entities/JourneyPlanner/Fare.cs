using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class Fare
    {
        [JsonProperty(PropertyName = "lowZone")]
        public int? LowZone { get; set; }

        [JsonProperty(PropertyName = "highZone")]
        public int? HighZone { get; set; }

        [JsonProperty(PropertyName = "cost")] public int? Cost { get; set; }

        [JsonProperty(PropertyName = "chargeProfileName")]
        public string ChargeProfileName { get; set; }

        [JsonProperty(PropertyName = "isHopperFare")]
        public bool? IsHopperFare { get; set; }

        [JsonProperty(PropertyName = "chargeLevel")]
        public string ChargeLevel { get; set; }

        [JsonProperty(PropertyName = "peak")] public int? Peak { get; set; }

        [JsonProperty(PropertyName = "offPeak")]
        public int? OffPeak { get; set; }

        [JsonProperty(PropertyName = "taps")] public List<FareTap> Taps { get; set; }
    }
}