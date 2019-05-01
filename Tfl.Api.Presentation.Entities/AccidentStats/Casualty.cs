using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.AccidentStats
{
    public class Casualty
    {
        [JsonProperty(PropertyName = "age")] public int? Age { get; set; }

        [JsonProperty(PropertyName = "class")] public string Class { get; set; }

        [JsonProperty(PropertyName = "severity")]
        public string Severity { get; set; }

        [JsonProperty(PropertyName = "mode")] public string Mode { get; set; }

        [JsonProperty(PropertyName = "ageBand")]
        public string AgeBand { get; set; }
    }
}