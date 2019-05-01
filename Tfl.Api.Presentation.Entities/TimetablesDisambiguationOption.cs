using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class TimetablesDisambiguationOption
    {
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "uri")] public string Uri { get; set; }
    }
}