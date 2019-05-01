using System;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class RoadDisruptionLine
    {
        [JsonProperty(PropertyName = "id")] public int? Id { get; set; }

        [JsonProperty(PropertyName = "roadDisruptionId")]
        public string RoadDisruptionId { get; set; }

        [JsonProperty(PropertyName = "isDiversion")]
        public bool? IsDiversion { get; set; }

        [JsonProperty(PropertyName = "multiLineString")]
        public DbGeography MultiLineString { get; set; }

        [JsonProperty(PropertyName = "startDate")]
        public DateTimeOffset? StartDate { get; set; }

        [JsonProperty(PropertyName = "endDate")]
        public DateTimeOffset? EndDate { get; set; }

        [JsonProperty(PropertyName = "startTime")]
        public string StartTime { get; set; }

        [JsonProperty(PropertyName = "endTime")]
        public string EndTime { get; set; }
    }
}