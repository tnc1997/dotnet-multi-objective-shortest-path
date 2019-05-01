using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.Fares
{
    public class PassengerType
    {
        [JsonProperty(PropertyName = "type")] public string Type { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "displayName")]
        public string DisplayName { get; set; }

        [JsonProperty(PropertyName = "displayOrder")]
        public int? DisplayOrder { get; set; }
    }
}