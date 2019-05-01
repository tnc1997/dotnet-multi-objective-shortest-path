using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class StatusSeverity
    {
        [JsonProperty(PropertyName = "modeName")]
        public string ModeName { get; set; }

        [JsonProperty(PropertyName = "severityLevel")]
        public int? SeverityLevel { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}