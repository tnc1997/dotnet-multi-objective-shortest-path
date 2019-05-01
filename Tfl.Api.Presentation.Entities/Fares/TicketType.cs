using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.Fares
{
    public class TicketType
    {
        [JsonProperty(PropertyName = "type")] public string Type { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}