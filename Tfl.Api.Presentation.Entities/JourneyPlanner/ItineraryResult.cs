using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class ItineraryResult
    {
        [JsonProperty(PropertyName = "journeys")]
        public List<Journey> Journeys { get; set; }

        [JsonProperty(PropertyName = "lines")] public List<Line> Lines { get; set; }

        [JsonProperty(PropertyName = "cycleHireDockingStationData")]
        public JourneyPlannerCycleHireDockingStationData CycleHireDockingStationData { get; set; }

        [JsonProperty(PropertyName = "stopMessages")]
        public List<string> StopMessages { get; set; }

        [JsonProperty(PropertyName = "recommendedMaxAgeMinutes")]
        public int? RecommendedMaxAgeMinutes { get; set; }

        [JsonProperty(PropertyName = "searchCriteria")]
        public SearchCriteria SearchCriteria { get; set; }

        [JsonProperty(PropertyName = "journeyVector")]
        public JourneyVector JourneyVector { get; set; }
    }
}