using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class JourneyFare
    {
        [JsonProperty(PropertyName = "totalCost")]
        public int? TotalCost { get; set; }

        [JsonProperty(PropertyName = "fares")] public List<Fare> Fares { get; set; }

        [JsonProperty(PropertyName = "caveats")]
        public List<FareCaveat> Caveats { get; set; }
    }
}