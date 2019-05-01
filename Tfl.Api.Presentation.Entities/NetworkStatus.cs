using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class NetworkStatus
    {
        [JsonProperty(PropertyName = "operator")]
        public string Operator { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "statusLevel")]
        public int? StatusLevel { get; set; }
    }
}