using System;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class CycleSuperhighway
    {
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        [JsonProperty(PropertyName = "label")] public string Label { get; set; }

        [JsonProperty(PropertyName = "labelShort")]
        public string LabelShort { get; set; }

        [JsonProperty(PropertyName = "geography")]
        public DbGeography Geography { get; set; }

        [JsonProperty(PropertyName = "segmented")]
        public bool? Segmented { get; set; }

        [JsonProperty(PropertyName = "modified")]
        public DateTimeOffset? Modified { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "routeType")]
        public string RouteType { get; set; }
    }
}