using System;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class AdditionalProperties
    {
        [JsonProperty(PropertyName = "category")]
        public string Category { get; set; }

        [JsonProperty(PropertyName = "key")] public string Key { get; set; }

        [JsonProperty(PropertyName = "sourceSystemKey")]
        public string SourceSystemKey { get; set; }

        [JsonProperty(PropertyName = "value")] public string Value { get; set; }

        [JsonProperty(PropertyName = "modified")]
        public DateTimeOffset? Modified { get; set; }
    }
}