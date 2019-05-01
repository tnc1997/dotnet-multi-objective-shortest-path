using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class RouteSequence
    {
        [JsonProperty(PropertyName = "lineId")]
        public string LineId { get; set; }

        [JsonProperty(PropertyName = "lineName")]
        public string LineName { get; set; }

        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }

        [JsonProperty(PropertyName = "isOutboundOnly")]
        public bool? IsOutboundOnly { get; set; }

        [JsonProperty(PropertyName = "mode")] public string Mode { get; set; }

        [JsonProperty(PropertyName = "lineStrings")]
        public List<string> LineStrings { get; set; }

        [JsonProperty(PropertyName = "stations")]
        public List<MatchedStop> Stations { get; set; }

        [JsonProperty(PropertyName = "stopPointSequences")]
        public List<StopPointSequence> StopPointSequences { get; set; }

        [JsonProperty(PropertyName = "orderedLineRoutes")]
        public List<OrderedRoute> OrderedLineRoutes { get; set; }
    }
}