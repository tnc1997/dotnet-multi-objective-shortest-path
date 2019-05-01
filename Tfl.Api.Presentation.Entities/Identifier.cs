using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class Identifier
    {
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "uri")] public string Uri { get; set; }

        [JsonProperty(PropertyName = "fullName")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "type")] public string Type { get; set; }

        [JsonProperty(PropertyName = "crowding")]
        public Crowding Crowding { get; set; }

        [JsonProperty(PropertyName = "routeType")]
        public string RouteType { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
    }
}