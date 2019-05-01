using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class PathAttribute
    {
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "value")] public string Value { get; set; }
    }
}