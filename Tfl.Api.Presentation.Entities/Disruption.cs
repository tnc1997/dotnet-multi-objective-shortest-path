using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class Disruption
    {
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "type")] public string Type { get; set; }

        [JsonProperty(PropertyName = "categoryDescription")]
        public string CategoryDescription { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "additionalInfo")]
        public string AdditionalInfo { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTimeOffset? Created { get; set; }

        [JsonProperty(PropertyName = "lastUpdate")]
        public DateTimeOffset? LastUpdate { get; set; }

        [JsonProperty(PropertyName = "affectedRoutes")]
        public List<RouteSection> AffectedRoutes { get; set; }

        [JsonProperty(PropertyName = "affectedStops")]
        public List<StopPoint> AffectedStops { get; set; }

        [JsonProperty(PropertyName = "closureText")]
        public string ClosureText { get; set; }
    }
}