using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class ChargeConnectorOccupancy
    {
        [JsonProperty(PropertyName = "id")] public int? Id { get; set; }

        [JsonProperty(PropertyName = "sourceSystemPlaceId")]
        public string SourceSystemPlaceId { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}