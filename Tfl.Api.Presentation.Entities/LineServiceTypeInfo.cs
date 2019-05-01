using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class LineServiceTypeInfo
    {
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "uri")] public string Uri { get; set; }
    }
}