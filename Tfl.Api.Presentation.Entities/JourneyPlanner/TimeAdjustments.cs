using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class TimeAdjustments
    {
        [JsonProperty(PropertyName = "earliest")]
        public TimeAdjustment Earliest { get; set; }

        [JsonProperty(PropertyName = "earlier")]
        public TimeAdjustment Earlier { get; set; }

        [JsonProperty(PropertyName = "later")] public TimeAdjustment Later { get; set; }

        [JsonProperty(PropertyName = "latest")]
        public TimeAdjustment Latest { get; set; }
    }
}