using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class ApiVersionInfo
    {
        [JsonProperty(PropertyName = "label")] public string Label { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTimeOffset? Timestamp { get; set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "assemblies")]
        public List<string> Assemblies { get; set; }
    }
}