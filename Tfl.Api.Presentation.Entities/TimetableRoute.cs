using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class TimetableRoute
    {
        [JsonProperty(PropertyName = "stationIntervals")]
        public List<StationInterval> StationIntervals { get; set; }

        [JsonProperty(PropertyName = "schedules")]
        public List<Schedule> Schedules { get; set; }
    }
}