using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class StopPointSequence
    {
        [JsonProperty(PropertyName = "lineId")]
        public string LineId { get; set; }

        [JsonProperty(PropertyName = "lineName")]
        public string LineName { get; set; }

        [JsonProperty(PropertyName = "direction")]
        public string Direction { get; set; }

        [JsonProperty(PropertyName = "branchId")]
        public int? BranchId { get; set; }

        [JsonProperty(PropertyName = "nextBranchIds")]
        public List<int?> NextBranchIds { get; set; }

        [JsonProperty(PropertyName = "prevBranchIds")]
        public List<int?> PrevBranchIds { get; set; }

        [JsonProperty(PropertyName = "stopPoint")]
        public List<MatchedStop> StopPoint { get; set; }

        [JsonProperty(PropertyName = "serviceType")]
        public string ServiceType { get; set; }
    }
}