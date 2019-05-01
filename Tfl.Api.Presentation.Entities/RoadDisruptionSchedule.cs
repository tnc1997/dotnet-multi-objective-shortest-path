using System;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class RoadDisruptionSchedule
    {
        [JsonProperty(PropertyName = "startTime")]
        public DateTimeOffset? StartTime { get; set; }

        [JsonProperty(PropertyName = "endTime")]
        public DateTimeOffset? EndTime { get; set; }
    }
}