using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities
{
    public class BikePointOccupancy
    {
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "bikesCount")]
        public int? BikesCount { get; set; }

        [JsonProperty(PropertyName = "emptyDocks")]
        public int? EmptyDocks { get; set; }

        [JsonProperty(PropertyName = "totalDocks")]
        public int? TotalDocks { get; set; }
    }
}