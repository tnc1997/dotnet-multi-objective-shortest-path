using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tfl.Api.Presentation.Entities.JourneyPlanner
{
    public class RouteOption
    {
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }

        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "directions")]
        public List<string> Directions { get; set; }

        [JsonProperty(PropertyName = "lineIdentifier")]
        public Identifier LineIdentifier { get; set; }
    }
}