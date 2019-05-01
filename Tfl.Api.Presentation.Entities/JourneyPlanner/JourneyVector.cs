using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class JourneyVector
    {
        [JsonProperty(PropertyName = "from")] public string From { get; set; }

        [JsonProperty(PropertyName = "to")] public string To { get; set; }

        [JsonProperty(PropertyName = "via")] public string Via { get; set; }

        [JsonProperty(PropertyName = "uri")] public string Uri { get; set; }
    }
}