using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class JourneyPlannerCycleHireDockingStationData
    {
        [JsonProperty(PropertyName = "originNumberOfBikes")]
        public int? OriginNumberOfBikes { get; set; }

        [JsonProperty(PropertyName = "destinationNumberOfBikes")]
        public int? DestinationNumberOfBikes { get; set; }

        [JsonProperty(PropertyName = "originNumberOfEmptySlots")]
        public int? OriginNumberOfEmptySlots { get; set; }

        [JsonProperty(PropertyName = "destinationNumberOfEmptySlots")]
        public int? DestinationNumberOfEmptySlots { get; set; }

        [JsonProperty(PropertyName = "originId")]
        public string OriginId { get; set; }

        [JsonProperty(PropertyName = "destinationId")]
        public string DestinationId { get; set; }
    }
}