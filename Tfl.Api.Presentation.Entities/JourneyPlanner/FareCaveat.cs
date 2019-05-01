using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class FareCaveat
    {
        [JsonProperty(PropertyName = "text")] public string Text { get; set; }

        [JsonProperty(PropertyName = "type")] public string Type { get; set; }
    }
}