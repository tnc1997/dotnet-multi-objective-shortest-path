using System;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class RoadCorridor
    {
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "group")] public string Group { get; set; }

        [JsonProperty(PropertyName = "statusSeverity")]
        public string StatusSeverity { get; set; }

        [JsonProperty(PropertyName = "statusSeverityDescription")]
        public string StatusSeverityDescription { get; set; }

        [JsonProperty(PropertyName = "bounds")]
        public string Bounds { get; set; }

        [JsonProperty(PropertyName = "envelope")]
        public string Envelope { get; set; }

        [JsonProperty(PropertyName = "statusAggregationStartDate")]
        public DateTimeOffset? StatusAggregationStartDate { get; set; }

        [JsonProperty(PropertyName = "statusAggregationEndDate")]
        public DateTimeOffset? StatusAggregationEndDate { get; set; }

        [JsonProperty(PropertyName = "url")] public string Url { get; set; }
    }
}