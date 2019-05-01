using System;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class PlannedWork
    {
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "createdDateTime")]
        public DateTimeOffset? CreatedDateTime { get; set; }

        [JsonProperty(PropertyName = "lastUpdateDateTime")]
        public DateTimeOffset? LastUpdateDateTime { get; set; }
    }
}