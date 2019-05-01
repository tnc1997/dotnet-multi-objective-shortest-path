using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class LineStatus
    {
        [JsonProperty(PropertyName = "id")] public int? Id { get; set; }

        [JsonProperty(PropertyName = "lineId")]
        public string LineId { get; set; }

        [JsonProperty(PropertyName = "statusSeverity")]
        public int? StatusSeverity { get; set; }

        [JsonProperty(PropertyName = "statusSeverityDescription")]
        public string StatusSeverityDescription { get; set; }

        [JsonProperty(PropertyName = "reason")]
        public string Reason { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTimeOffset? Created { get; set; }

        [JsonProperty(PropertyName = "modified")]
        public DateTimeOffset? Modified { get; set; }

        [JsonProperty(PropertyName = "validityPeriods")]
        public List<ValidityPeriod> ValidityPeriods { get; set; }

        [JsonProperty(PropertyName = "disruption")]
        public Disruption Disruption { get; set; }
    }
}