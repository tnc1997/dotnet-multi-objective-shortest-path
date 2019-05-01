using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.Fares
{
    public class FaresMode
    {
        [JsonProperty(PropertyName = "id")] public int? Id { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}